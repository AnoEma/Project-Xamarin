using ProjectXamarinApp.Data;
using SQLite;
using System.IO;

namespace ProjectXamarinApp.iOS.Data
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteAndroid()
        {
        }
        public SQLiteConnection GetConnection()
        {
            var fileName = "TestDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Lirary");
            var path = Path.Combine(libraryPath, fileName);
            var connection = new SQLite.SQLiteConnection(path);

            return connection;
        }
    }
}