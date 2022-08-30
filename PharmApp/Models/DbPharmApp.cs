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
using PharmApp.DrugsInfo;

namespace PharmApp.Models
{
    class DbPharmApp
    {

        string DBPath =
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        SQLiteConnection dbConn;
        public DbPharmApp()
        {
          
                DBPath += "/DBPharm.db3";
                dbConn = new SQLite.SQLiteConnection(DBPath);
                dbConn.CreateTable<TblDrugsInfo>();
         
           
        }
        public void tblDrugInsert(TblDrugsInfo model)
        {
            
                dbConn.Insert(model);
            
            //foreach (var item in model)
            //{
            //    dd.PersianName = item.PersianName;
            //    dd.EnglishName = item.EnglishName;
            //    dd.PharmacologicalAndClinicalClassification = item.PharmacologicalAndClinicalClassification;
            //    dd.CommercialNAme = item.CommercialNAme;
            //    dd.ClassificationConsumptionInPregnancy = item.ClassificationConsumptionInPregnancy;
            //    dd.IranianGenericProducts = item.IranianGenericProducts;
            //    dd.MechanismOfAction = item.MechanismOfAction;
            //    dd.Indications = item.Indications;
            //    dd.DosageAndMethodOfAdministration = item.DosageAndMethodOfAdministration;
            //    dd.Pharmacokinetics = item.Pharmacokinetics;
            //    dd.ContraindicationsAndPrecautions = item.ContraindicationsAndPrecautions;
            //    dd.DrugInteractions = item.DrugInteractions;
            //    dd.sideEffects = item.sideEffects;
            //    dd.NursingCare = item.NursingCare;
            //    dd.PatientEducationFamily = item.PatientEducationFamily;
            //    dbConn.Insert(dd);

            //}
        }
        public List<TblDrugsInfo> tblDrugGetAll()
        {
            return dbConn.Query<TblDrugsInfo>("SELECT * FROM TblDrugsInfo");
        }
        public TblDrugsInfo tblDrugFindById(int id)
        {
            return dbConn.Find<TblDrugsInfo>(id);
            //dbConn.Query<tblProduct>("SELECT * FROM tblProduct WHERE id=?", id).FirstOrDefault();
        }

        public string DeleteAll()
        {
                dbConn.Query<TblDrugsInfo>("DELETE  FROM TblDrugsInfo");
            return "Deleted";
        }
    }
}