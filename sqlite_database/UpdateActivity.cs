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
    [Activity(Label = "UpdateActivity")]
    public class UpdateActivity : Activity
    {
        Button btn_get;
        Button btn_update;
        EditText txt_id;
        EditText txt_updatename;
        EditText txt_updatenickname;
        EditText txt_updatedept;
        EditText txt_updateplace;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here  
            SetContentView(Resource.Layout.UpdateAct);
            txt_updatename = FindViewById<EditText>(Resource.Id.edit1);
            txt_updatenickname = FindViewById<EditText>(Resource.Id.edit2);
            txt_updatedept = FindViewById<EditText>(Resource.Id.edit3);
            txt_updateplace = FindViewById<EditText>(Resource.Id.edit4);
            txt_id = FindViewById<EditText>(Resource.Id.updatetext);
            btn_get = FindViewById<Button>(Resource.Id.updatebtn);
            btn_update = FindViewById<Button>(Resource.Id.update1);
            btn_get.Click += Btn_get_Click;
            btn_update.Click += Btn_update_Click;
        }
        private void Btn_get_Click(object sender, EventArgs e)
        {
            //clear();  
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "student.db3"); //Call Database  
            var db = new SQLiteConnection(dpPath);
            var data = db.Table<table>(); //Call Table  
            int idvalue = Convert.ToInt32(txt_id.Text);
            var data1 = (from values in data
                         where values.id == idvalue
                         select new table
                         {
                             StudentName = values.StudentName,
                             NickName = values.NickName,
                             Dept = values.Dept,
                             Place = values.Place
                         }).ToList<table>();
            if (data1.Count > 0)
            {
                foreach (var val in data1)
                {
                    txt_updatename.Text = val.StudentName;
                    txt_updatenickname.Text = val.NickName;
                    txt_updatedept.Text = val.Dept;
                    txt_updateplace.Text = val.Place;
                }
            }
            else
            {
                Toast.MakeText(this, "Student Data Not Available", ToastLength.Short).Show();
            }
        }
        public List<string> GetData()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.Personal), "database.db3");
            var db = new SQLiteConnection(dbPath);
            List<string> data = new List<string>();
            foreach (var item in db.Table<table>())
            {
                var a = item.StudentName.ToString();
                var b = item.StudentName.ToString();
                var c = item.StudentName.ToString();
                var d = item.StudentName.ToString();
                data.Add(a);
                data.Add(b);
                data.Add(c);
                data.Add(d);
            }
            return data;

        }
        private void Btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "student.db3"); //Call Database  
                var db = new SQLiteConnection(dpPath);
                var data = db.Table<table>();
                int idvalue = Convert.ToInt32(txt_id.Text);
                var data1 = (from values in data
                             where values.id == idvalue
                             select values).Single();
                data1.StudentName = txt_updatename.Text;
                data1.NickName = txt_updatenickname.Text;
                data1.Dept = txt_updatedept.Text;
                data1.Place = txt_updateplace.Text;
                db.Update(data1);
                Toast.MakeText(this, "Updated Successfully", ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}