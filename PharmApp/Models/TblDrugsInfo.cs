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
using SQLite;

namespace PharmApp.Models
{
    public class TblDrugsInfo
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        public string PersianName { get; set; }

        public string EnglishName { get; set; }

        public string CommercialName { get; set; }
        public string Type { get; set; }
        public string PercentageTotalSolidity { get; set; }
        public string DimensionalChangeCoefficient { get; set; }
        public string PercentageCohesion { get; set; }
        public string AverageMoistureContentGreenWood { get; set; }
        public string SpecificGravityMoisture { get; set; }

        public string Des { get; set; }
        public string ImageLinkAddress { get; set; }
        public string Des1 { get; set; }

        public string ImageLinkAddress1 { get; set; }
        public string Des2 { get; set; }

        public string ImageLinkAddress2 { get; set; }
    }
}