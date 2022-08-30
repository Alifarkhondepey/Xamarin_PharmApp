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
using PharmApp.Assets;
using PharmApp.Controller;
using PharmApp.Models;
using PharmApp.DrugsInfo;

namespace PharmApp
{
    class RazorStartPageInterFace: Java.Lang.Object
    {
        Activity activity;
        WebView webview;

        public RazorStartPageInterFace(Activity _activity, WebView _webview)
        {
            activity = _activity;
            webview = _webview;
        }
        [Export]
        [JavascriptInterface]
        public void RedirectIndex()
        {
            try
            {

                activity.RunOnUiThread(() =>
                {
                    var intent = new Intent(Android.App.Application.Context, typeof(MainActivity));
                    intent.SetFlags(ActivityFlags.NewTask);
                    Application.Context.StartActivity(intent);
                });

            }
            catch (Exception e)
            {
                Toast.MakeText(activity, e.Message, ToastLength.Long).Show();
            }


        }
    }
}