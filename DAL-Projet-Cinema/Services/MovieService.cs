using DAL_Projet_Cinema.Entities;
using DAL_Projet_Cinema.Mappers;
using Microsoft.Extensions.Configuration;
using Shared_Projet_Cinema.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace DAL_Projet_Cinema.Services
{
    public class MovieService : BaseService, IMovieRepository<Movie>
    {
        public MovieService(IConfiguration configuration) : base(configuration, "projet-cinema")
        {}

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Movie_Delete";
                    command.Parameters.AddWithValue("id_movie", id);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0) throw new ArgumentOutOfRangeException(nameof(id),$"L'identifiant {id} ne correspond à aucune valeur");
                }
            }
        }

        public IEnumerable<Movie> Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Movie_GetAll";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToMovie();
                        }
                    }
                }
            }
        }

        public Movie Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Movie_GetById";
                    command.Parameters.AddWithValue("id_movie", id);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) return reader.ToMovie();
                        throw new ArgumentOutOfRangeException(nameof(id), $"L'identifiant {id} ne correspond à aucune valeur");
                    }
                }
            }
        }

        public int Insert(Movie entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Movie_Insert";
                    command.Parameters.AddWithValue("title", entity.Title);
                    command.Parameters.AddWithValue("subTitle", (object?)entity.SubTitle?? DBNull.Value);
                    command.Parameters.AddWithValue("releaseYear", entity.ReleaseYear);
                    command.Parameters.AddWithValue("synopsis", entity.Synopsis);
                    command.Parameters.AddWithValue("posterUrl", entity.PosterUrl);
                    command.Parameters.AddWithValue("duration", entity.Duration);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(Movie entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Movie_Update";
                    command.Parameters.AddWithValue("id_movie", entity.Id_Movie);
                    command.Parameters.AddWithValue("title", entity.Title);
                    command.Parameters.AddWithValue("subTitle", (object?)entity.SubTitle ?? DBNull.Value);
                    command.Parameters.AddWithValue("releaseYear", entity.ReleaseYear);
                    command.Parameters.AddWithValue("synopsis", entity.Synopsis);
                    command.Parameters.AddWithValue("posterUrl", entity.PosterUrl);
                    command.Parameters.AddWithValue("duration", entity.Duration);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0) throw new ArgumentOutOfRangeException(nameof(entity.Id_Movie), $"L'identifiant {entity.Id_Movie} ne correspond à aucune valeur");
                }
            }
        }
    }
}
