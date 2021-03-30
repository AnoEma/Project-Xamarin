using SQLite;

namespace ProjectXamarinApp.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}