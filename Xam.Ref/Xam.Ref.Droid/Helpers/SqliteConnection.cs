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
using Xam.Ref.Infra.Interfaces;
using System.IO;

namespace Xam.Ref.Droid.Helpers
{
    public class SqliteConnection : IDataConnection
    {
        public object GetConnection()
        {
            //name of the local DB
            var sqliteFilename = "mylocaldb";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);

            // Return the database connection 
            return conn;
        }
    }
}