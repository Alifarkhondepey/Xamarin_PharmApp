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
using Java.Lang;
using PharmApp.DrugsInfo;
using PharmApp.Models;

namespace PharmApp.Controller
{
    [Activity(Label = "Physical Properties", MainLauncher = true, Icon = "@drawable/Icon", Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen")]

    public class StartPageActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.StartPage);
            // Create your application here

         
            var webview = FindViewById<WebView>(Resource.Id.webView5);
            webview.Settings.JavaScriptEnabled = true;
            webview.Settings.SetRenderPriority(WebSettings.RenderPriority.High);
            webview.AddJavascriptInterface(new RazorStartPageInterFace(this, webview),
                "RazorStartPageInterFace");
            var p = new RazorStartPage() { };
            var html = p.GenerateString();
            webview.LoadDataWithBaseURL("file:///android_asset/", html, "text/html", "utf-8", null);
            Toast.MakeText(this, "لطفا اینترنت خود را برای دریافت و یا آپدیت لیست چوب ها وصل کنید سپس روی دکمه ورود کلیک کنید  ", ToastLength.Long).Show();


        }
        public override void OnBackPressed()
        {
            new AlertDialog.Builder(this).SetTitle("اخطار").SetMessage("خروج از برنامه ؟")
                               .SetNegativeButton("نه", delegate { }).
                               SetPositiveButton("بله", delegate
                               {
                                   Java.Lang.JavaSystem.Exit(0);

                                    //System.Environment.Exit(0);
                                    //activity.Finish();
                                    //activity.FinishAffinity();
                                    //Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                                }).Show();
        }

    }


}