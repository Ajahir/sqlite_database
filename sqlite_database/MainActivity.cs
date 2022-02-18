using Android.App;
using Android.OS;

using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using SQLite;
using System.IO;

namespace sqlite_database
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btninsert;
        Button btnselect;
        Button btnupdate;
        Button btndelete;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_main);
            btninsert = FindViewById<Button>(Resource.Id.button1);
            btnselect = FindViewById<Button>(Resource.Id.button2);
            btnupdate = FindViewById<Button>(Resource.Id.button3);
            btndelete = FindViewById<Button>(Resource.Id.button4);
            CreateDB(); //Calling DB Creation method  
            btninsert.Click += delegate { StartActivity(typeof(InsertActivity)); };
           btnselect.Click += delegate { StartActivity(typeof(SelectActivity)); };
           btnupdate.Click += delegate { StartActivity(typeof(UpdateActivity)); };
            btndelete.Click += delegate { StartActivity(typeof(DeleteActivity)); };
        }
        public string CreateDB()
        {
            var output = "";
            output += "Creating Databse if it doesnt exists";
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "student.db3"); //Create New Database  
            var db = new SQLiteConnection(dpPath);
            output += "\n Database Created....";
            return output;
        }
    }
}