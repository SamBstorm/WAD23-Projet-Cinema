using System.Data.SqlClient;
using BLL_Projet_Cinema.Entities;

namespace Console_DEV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Test DB
            /*short result;
            string connectionString = $@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB-Projet-Cinema;Integrated Security=True;Encrypt=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Select [ReleaseYear] FROM Movie WHERE Id_Movie = 1";
                    connection.Open();
                    result = (short)command.ExecuteScalar();
                }
            }

            Console.WriteLine(result);*/
            #endregion
            #region Test BLL
            Movie movie = new Movie("Argylle", null, 2024, "Agent secret d'un roman devient réalité", "argylle.png", 120);
            CinemaPlace cinema = new CinemaPlace(1, "Eldorado", "Namur", "Rue de fer", "32");
            cinema.AddRoom(
                new CinemaRoom(320, 1, 1600, 900, true, true)
                );
            cinema.AddDiffusion(
                new Diffusion(DateTime.Now, Language.French, null, cinema[1],movie)
                );
            Console.WriteLine($"Bienvenue à l'{cinema.Name} de {cinema.City}");
            Console.WriteLine($"Le cinéma compte : {cinema.Rooms.Count()} salle(s).");
            foreach (CinemaRoom room in cinema.Rooms)
            {
                Console.WriteLine($"Salle n°{room.Number}");
                Console.WriteLine("Diffusions : ");
                foreach (Diffusion diffusion in room.Diffusions)
                {
                    Console.WriteLine($"{diffusion.DiffusionDateTime} : {diffusion.Movie.Title} {diffusion.AudioLang} {(diffusion.SubTitleLang?.ToString() ?? "Sans sous-titre")}");
                }
            }
            #endregion
        }
    }
}
