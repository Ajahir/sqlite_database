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
    [Activity(Label = "InsertActivity")]
    public class InsertActivity : Activity
    {


        Button btncreate,viewbtn;
        EditText txtname;
        EditText txtnickname;
        EditText txtdept;
        EditText txtplace;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here  
            SetContentView(Resource.Layout.InsertAct);
            txtname = FindViewById<EditText>(Resource.Id.editText1);
            txtnickname = FindViewById<EditText>(Resource.Id.editText2);
            txtdept = FindViewById<EditText>(Resource.Id.editText3);
            txtplace = FindViewById<EditText>(Resource.Id.editText4);
            btncreate = FindViewById<Button>(Resource.Id.button5);
            viewbtn = FindViewById<Button>(Resource.Id.view1);
            btncreate.Click += Btncreate_Click;
            viewbtn.Click += Viewbtn_Click;

        }

        private void Viewbtn_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ViewActivity));
        }

        private void Btncreate_Click(object sender, EventArgs e)
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "student.db3");
                var db = new SQLiteConnection(dpPath);
                db.CreateTable<table>();
                table tbl = new table();
                tbl.StudentName = txtname.Text;
                tbl.NickName = txtnickname.Text;
                tbl.Dept = txtdept.Text;
                tbl.Place = txtplace.Text;
                db.Insert(tbl);
                clear();
                Toast.MakeText(this, "Record Added Successfully...,", ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
        public List<string> GetData()
        {
           /* string dbPath = Path.Combine(System.Environment.GetFolderPath
               (System.Environment.SpecialFolder.Personal), "student.db3");
            var db = new SQLiteConnection(dbPath);
            List<string> data = new List<string>();
            foreach (var item in db.Table<table>())
            {
                var a = item.StudentName.ToString();
                var b = item.NickName.ToString();
                var c = item.Dept.ToString();
                var d = item.Place.ToString();
                data.Add(a);
                data.Add(b);
                data.Add(c);
                data.Add(d);
            }
            return data;*/string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "student.db3"); //Call Database  
            var db = new SQLiteConnection(dpPath);
            List<string> data = new List<string>();
             //Call Table  
            
           
                foreach (var item in db.Table<table>())
                {
                    var a = item.StudentName.ToString();
                    var b = item.NickName.ToString();
                    var c = item.Dept.ToString();
                    var d = item.Place.ToString();

                data.Add(a);
                data.Add(b);
                data.Add(c);
                data.Add(d);
            }
            return data;


        }
        void clear()
        {
            txtname.Text = "";
            txtnickname.Text = "";
            txtdept.Text = "";
            txtplace.Text = "";
        }
    }
} 