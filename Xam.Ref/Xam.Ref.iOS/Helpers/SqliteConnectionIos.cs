using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xam.Ref.Infra.Interfaces;
using Xam.Ref.iOS.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteConnectionIos))]
namespace Xam.Ref.iOS.Helpers
{
    public class SqliteConnectionIos : IDataConnection
    {
        public object GetConnection()
        {
            var sqliteFilename = "TodoSQLite.db3";
            string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);
            // Create the connection
            var conn = new SQLite.SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}
