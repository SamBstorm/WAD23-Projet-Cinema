using System.Data.SqlClient;

namespace Console_DEV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            short result;
            string connectionString = $@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB-Projet-Cinema;Integrated Security=True;Encrypt=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Select [ReleaseYear] FROM Movie WHERE Id_Movie = 1";
                    connection.Open();
                    result = (short) command.ExecuteScalar();
                }
            }

            Console.WriteLine(result);
        }
    }
}
