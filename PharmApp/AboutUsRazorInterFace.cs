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
using PharmApp.Controller;
using PharmApp.Models;

namespace PharmApp
{
    class AboutUsRazorInterFace:Java.Lang.Object
    {
        Activity activity;
        WebView webview;
        public AboutUsRazorInterFace(Activity _activity, WebView _webview)
        {
            activity = _activity;
            webview = _webview;
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
        public void ShowDetails(int id)
        {
            var intent = new Intent(activity, typeof(DrugDetailsActivity));
            intent.PutExtra("id", id);
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


            //Post Back
            //var p = new IndexRazor() { Model = GlobalInfos.drugsInfo.Where(x => x.EnglishName.ToLower().Contains(name.ToLower()) || x.PersianName.ToLower().Contains(name.ToLower())).ToArray() };
            //var p = new IndexRazor() { Model = db.tblDrugGetAll().Where(x => x.EnglishName.ToLower().Contains(name.ToLower()) || x.PersianName.ToLower().Contains(name.ToLower())).ToArray() };
            //var html = p.GenerateString();
            //try
            //{
            //    activity.RunOnUiThread(() =>
            //    {
            //        webview.LoadDataWithBaseURL("file:///android_asset/", html, "text/html", "utf-8", null);
            //    });
            //}
            //catch (Exception ex)
            //{

            //}
        }

    }
}