using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sqlite_database
{
    [Activity(Label = "ViewActivity")]
    public class ViewActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ViewAct);
            InsertActivity dbr = new InsertActivity();

            //create table (if it doesn't exist)
           

            var items = dbr.GetData();
            var listView = FindViewById<ListView>(Resource.Id.listView1);

            listView.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line, items);
        }
    }
}