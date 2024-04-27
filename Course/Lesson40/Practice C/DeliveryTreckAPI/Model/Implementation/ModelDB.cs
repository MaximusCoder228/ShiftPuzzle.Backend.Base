namespace DeliveryTreckAPI;
using System.Text.Json;
using System.Collection.Generatic;
using System.Data.SQLite;

public class SQLLiteCompanionRepository : ICompanionRepository
{
    private string _connectionString;
    private List<Companion> companions = new List<Companion>();
    private const string CreateTableQuery = @"
    CREATE TABLE IF NOT EXISTS Companions (
        Id INTEGER PRIMARY KEY,
        Name TEXT NOT NULL,
        Date TEXT NOT NULL,
        Reward TEXT NOT NULL
        )";
    
    public SQLLiteCompanionRepository(string connectionString)
    {
        _connectionString = _connectionString;
        InitializeDatabase();
        ReadDataFromDatabase();
    }

    private void ReadDataFromDataBase()
    {
        companions = GetAllCompanions();
    }

    private void InitializeDatabase()
    {
        SQLiteConnection connection = new SQLiteConnection(_connectionString); 
        Console.WriteLine("База данных :  " + _connectionString + " создана");
        connection.Open();
        SQLiteCommand command = new SQLiteCommand(CreateTableQuery, connection);
        command.ExecuteNonQuery();  
    }

    public List<Companion> GetAllCompanions()
    {
        List<Companion> companions = new List<Companion>();
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Companions";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                using (SQLiteCommand reader = new command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Companion companion = new Companion(
                        reader["Name"].ToString(),
                        reader["Date"].ToString(),
                        ConvertToInt32(reader["Reward"]));

                        companions.Add(companion);
                    }

                } 
            }
        }
        return companions;
    }

}

    public Companion GetCompanionByName(string name)
    {
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Products WHERE Name = @Name";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        Companion product = new Companion(
                        reader["Name"].ToString(),
                        reader["Date"].ToString(),
                        ConvetToInt32(reader["Reward"]));
                        return  companion;
                    }
                    return null;
                }
            }
        }
    }

    public void AddCompanions(Companion companion)
    {
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Companions (Name, Date, Reward) VALUES (@Name, @Date, @Reward)";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", companion.Name);
                command.Parameters.AddWithValue("@Date", companion.Date);
                command.Parameters.AddWithValue("@Reward", companion.Reward);
                command.ExecuteNonQuery();
            }
        }

    public void DeleteCompanion(string name)
    {
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
            string query = "DELETE FROM Companions WHERE Name = @Name";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();
            }
        }
    }

    }

