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
using PharmApp.DrugsInfo;

namespace PharmApp.Controller
{
    public static class GlobalInfos
    {
        public static List<ExcelData> drugsInfo { get; set; }
    }
}
