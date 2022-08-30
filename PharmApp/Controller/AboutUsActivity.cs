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
using PharmApp.Assets;

namespace PharmApp.Controller
{
    [Activity(Label = "Physical Properties", Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen")]
    public class AboutUsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AboutUs);

            // Create your application here
            var webview = FindViewById<WebView>(Resource.Id.webView41);
            webview.Settings.JavaScriptEnabled = true;
            webview.Settings.SetRenderPriority(WebSettings.RenderPriority.High);
            var p = new RazorAboutUs() { };
            var html = p.GenerateString();
            webview.LoadDataWithBaseURL("file:///android_asset/", html, "text/html", "utf-8", null);
            webview.AddJavascriptInterface(new AboutUsRazorInterFace(this, webview),
               "AboutUsRazorInterFace");

        }
    }
}