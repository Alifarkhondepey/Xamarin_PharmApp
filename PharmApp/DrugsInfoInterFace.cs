using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Webkit;
using Java.Interop;
using PharmApp.Models;
using PharmApp.Controller;

namespace PharmApp.Assets
{
    class DrugsInfoInterFace : Java.Lang.Object
    {
        Activity activity;
        WebView webview;
        public DrugsInfoInterFace(Activity _activity, WebView _webview)
        {
            activity = _activity;
            webview = _webview;
        }
        [Export]
        [JavascriptInterface]
        public void ShowDetails(int id)
        {
            var intent = new Intent(activity, typeof(DrugDetailsActivity));
            intent.PutExtra("id", id);
            activity.StartActivity(intent);
        }
        [Export]
        [JavascriptInterface]
        public void RedirectHelpView()
        {
            var intent = new Intent(activity, typeof(HelpActivity));
            activity.StartActivity(intent);
        }
        [Export]
        [JavascriptInterface]
        public void RedirectAboutUs()
        {
            var intent = new Intent(activity, typeof(AboutUsActivity));
            activity.StartActivity(intent);
        }
        [Export]
        [JavascriptInterface]
        public void SearchByName(string name)
        {
            DbPharmApp db = new DbPharmApp();
            var model = db.tblDrugGetAll()
                .Where(x => x.EnglishName.ToLower().Contains(name.ToLower()) || x.PersianName.ToLower().Contains(name.ToLower()))
                .Select(x => new { PersianName = x.PersianName, EnglishName = x.EnglishName, Id = x.Id, CommercialNAme = x.CommercialName }).ToArray();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            //callback (ajax)
            activity.RunOnUiThread(() =>
            {
                webview.LoadUrl(string.Format("javascript: OnlineSearchResult('{0}')", json));

            });
        }

       
    }
}