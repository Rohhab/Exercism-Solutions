public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database) => this.database = database;

    public void Write(string data)
    {
        using(database)
        {
            database.BeginTransaction();
            database.Write(data);
            database.EndTransaction();
        }
    }
    
    public bool WriteSafely(string data)
    {
        try
        {
            Write(data);
            return true;
        }
        catch(InvalidOperationException)
        {
            return false;
        }
    }

    public void Dispose()
    {
        database.Dispose();
    }
}
