using Microsoft.Data.SqlClient;

// Your connection string — uses Windows Authentication (no password needed)
string connectionString =
    "Server=.\\SQLEXPRESS;Database=MyFirstDB;Integrated Security=True;TrustServerCertificate=True;";

Console.WriteLine("Connecting to SQL Server...\n");

try
{
    // 1. Open connection
    using SqlConnection connection = new SqlConnection(connectionString);
    connection.Open();
    Console.WriteLine("Connected successfully!\n");

    // 2. SQL query
    string query = "SELECT Id, Name, Age, Grade FROM Students";

    // 3. Create command
    using SqlCommand command = new SqlCommand(query, connection);

    // 4. Read results
    using SqlDataReader reader = command.ExecuteReader();

    Console.WriteLine("ID  | Name     | Age | Grade");
    Console.WriteLine("----|----------|-----|------");

    while (reader.Read())
    {
        int id = reader.GetInt32(0);
        string name = reader.GetString(1);
        int age = reader.GetInt32(2);
        string grade = reader.GetString(3);

        Console.WriteLine($"{id,-4}| {name,-9}| {age,-4}| {grade}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();