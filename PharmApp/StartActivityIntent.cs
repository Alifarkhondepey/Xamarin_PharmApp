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
using PharmApp.Controller;

namespace PharmApp
{
    public class StartActivityIntent:Activity
    {
        public void ss(int id, Activity _activity)
        {
            Intent intent = new Intent(_activity, typeof(DrugDetailsActivity));
            intent.PutExtra("DrugId", id);
            StartActivity(intent);
        }

    }
}