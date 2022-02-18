using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace sqlite_database
{
    [Activity(Label = "DeleteActivity")]
    public class DeleteActivity : Activity
    {
        Button btn_delete;
        EditText txt_delete_id;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here  
            SetContentView(Resource.Layout.DeleteAct);
            txt_delete_id = FindViewById<EditText>(Resource.Id.deletetext);
            btn_delete = FindViewById<Button>(Resource.Id.deletebtn);
            btn_delete.Click += Btn_delete_Click;
        }
        private void Btn_delete_Click(object sender, EventArgs e)
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "student.db3"); //Call Database  
            var db = new SQLiteConnection(dpPath);
            var data = db.Table<table>();
            int idvalue = Convert.ToInt32(txt_delete_id.Text);
            var data1 = data.Where(x => x.id == idvalue).FirstOrDefault();
            if (data1.id != null)
            {
                db.Delete(data1);
                Toast.MakeText(this, "Delete Successfully", ToastLength.Short).Show();
                txt_delete_id.Text = "";
            }
            else
            {
                Toast.MakeText(this, "Not Found", ToastLength.Short).Show();
            }
        }
    }
}