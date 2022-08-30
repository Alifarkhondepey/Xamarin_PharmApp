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
using PharmApp.DrugsInfo;
using PharmApp.Assets;
using PharmApp.Models;

namespace PharmApp.Controller
{
    [Activity(Label = "Physical Properties", Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen")]
    public class DrugDetailsActivity : Activity
    {
        DbPharmApp db = new DbPharmApp();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DrugDetails);
            // Create your application here
            var webview = FindViewById<WebView>(Resource.Id.webView2);
            webview.Settings.JavaScriptEnabled = true;
            webview.Settings.SetRenderPriority(WebSettings.RenderPriority.High);
            webview.AddJavascriptInterface(new DrugsInfoInterFace(this, webview),
                "DrugsInfoInterFace");
            int id = Intent.GetIntExtra("id", 0);
            //var foundDrug = GlobalInfos.drugsInfo.Find(x => x.Id == id);
            var dbdrug = db.tblDrugGetAll().Find(x=>x.Id==id);

            //ExcelData[] drug = di.GetData();
            var p = new RazorDrugDetails() {Model = dbdrug };
            var html = p.GenerateString();
            webview.LoadDataWithBaseURL("file:///android_asset/", html, "text/html", "utf-8", null);
        }
    }
}