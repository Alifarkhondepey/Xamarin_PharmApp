using Android.App;
using Android.Widget;
using Android.OS;
using Android.Webkit;
using PharmApp.Assets;
using PharmApp.DrugsInfo;
using PharmApp.Controller;
using System.Linq;
using PharmApp.Models;
using Plugin.Connectivity;

namespace PharmApp
{
    [Activity(Label = "Physical Properties", Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            DbPharmApp db = new DbPharmApp();

            // Set our view from the "main" layout resource
            //var webview = FindViewById<WebView>(Resource.Id.webView1);
            //webview.Settings.JavaScriptEnabled = true;
            //webview.Settings.SetRenderPriority(WebSettings.RenderPriority.High);
            //webview.AddJavascriptInterface(new IndexRazorInterFace(this, webview),
            //    "IndexInterFace");

            ////GlobalInfos.drugsInfo.ToArray()
            //var p = new IndexRazor() { };
            //var html = p.GenerateString();
            //webview.LoadDataWithBaseURL("file:///android_asset/", html, "text/html", "utf-8", null);
            try
            {
                var t = db.tblDrugGetAll().FirstOrDefault();
                if ( t == null)
                {
                    
                    ReadDrugsInfo di = new ReadDrugsInfo();
                    ExcelData[] drug = di.GetData();
                    TblDrugsInfo dd = new TblDrugsInfo();

                    foreach (var item in drug)
                    {
                        dd.PersianName = item.PersianName;
                        dd.EnglishName = item.EnglishName;
                        dd.CommercialName = item.CommercialName;
                        dd.AverageMoistureContentGreenWood = item.AverageMoistureContentGreenWood;
                        dd.DimensionalChangeCoefficient = item.DimensionalChangeCoefficient;
                        dd.Type = item.Type;
                        dd.SpecificGravityMoisture = item.SpecificGravityMoisture;
                        dd.PercentageTotalSolidity = item.PercentageTotalSolidity;
                        dd.PercentageCohesion = item.PercentageCohesion;
                        dd.Des = item.Des;
                         db.tblDrugInsert(dd);


                    }
                }
                else
                {
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        var result = db.DeleteAll();

                        if (result == "Deleted")
                        {
                            ReadDrugsInfo di = new ReadDrugsInfo();
                            ExcelData[] drug = di.GetData();
                            TblDrugsInfo dd = new TblDrugsInfo();

                            foreach (var item in drug)
                            {
                                dd.PersianName = item.PersianName;
                                dd.EnglishName = item.EnglishName;
                                dd.CommercialName = item.CommercialName;
                                dd.AverageMoistureContentGreenWood = item.AverageMoistureContentGreenWood;
                                dd.DimensionalChangeCoefficient = item.DimensionalChangeCoefficient;
                                dd.Type = item.Type;
                                dd.SpecificGravityMoisture = item.SpecificGravityMoisture;
                                dd.PercentageTotalSolidity = item.PercentageTotalSolidity;
                                dd.PercentageCohesion = item.PercentageCohesion;
                                dd.Des = item.Des;
                                db.tblDrugInsert(dd);


                            }
                        }
                    }
                   
                 
                }
                var dbdrug = db.tblDrugGetAll().ToArray();

                var webview = FindViewById<WebView>(Resource.Id.webView1);
                webview.Settings.JavaScriptEnabled = true;
                webview.Settings.SetRenderPriority(WebSettings.RenderPriority.High);
                webview.AddJavascriptInterface(new IndexRazorInterFace(this, webview),
                    "IndexInterFace");

               // GlobalInfos.drugsInfo.ToArray();
                var p = new IndexRazor() { Model = dbdrug };
                var html = p.GenerateString();
                webview.LoadDataWithBaseURL("file:///android_asset/", html, "text/html", "utf-8", null);
            }
            catch (System.Exception e)
            {
                Toast.MakeText(this, "لطفا اینترنت خود را برای نصب اولیه اپلیکیشن وصل کنید اگر وصل می باشد پیام بعدی را برای پشتیبانی ارسال کنید ", ToastLength.Long).Show();
                Toast.MakeText(this, e.Message, ToastLength.Long).Show();
            }

            //GlobalInfos.drugsInfo = drug.ToList();
            //ActionBar.Hide();



        }
    }
}

