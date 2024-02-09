using DAL_Projet_Cinema.Entities;
using Microsoft.Extensions.Configuration;
using Shared_Projet_Cinema.Repositories;
using System.Data.SqlClient;
using System.Data;
using DAL_Projet_Cinema.Mappers;

namespace DAL_Projet_Cinema.Services
{
    public class DiffusionService : BaseService, IDiffusionRepository<Diffusion>
    {
        public DiffusionService(IConfiguration configuration) : base(configuration, "projet-cinema")
        {
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Diffusion_Delete";
                    command.Parameters.AddWithValue("id_diffusion", id);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0) throw new ArgumentOutOfRangeException(nameof(id), $"L'identifiant {id} ne correspond à aucune valeur");
                }
            }
        }

        public IEnumerable<Diffusion> Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Diffusion_GetAll";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToDiffusion();
                        }
                    }
                }
            }
        }

        public Diffusion Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Diffusion_GetById";
                    command.Parameters.AddWithValue("id_diffusion", id);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) return reader.ToDiffusion();
                        throw new ArgumentOutOfRangeException(nameof(id), $"L'identifiant {id} ne correspond à aucune valeur");
                    }
                }
            }
        }

        public IEnumerable<Diffusion> GetByCinemaPlace(int id_cinemaPlace)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Diffusion> GetByDate(DateTime diffusionDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Diffusion> GetByMovie(int id_movie)
        {
            throw new NotImplementedException();
        }

        public int Insert(Diffusion entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Diffusion_Insert";
                    command.Parameters.AddWithValue("diffusionDate", entity.DiffusionDate);
                    command.Parameters.AddWithValue("diffusionTime", entity.DiffusionTime);
                    command.Parameters.AddWithValue("audioLang", entity.AudioLang);
                    command.Parameters.AddWithValue("subTitleLang", entity.SubTitleLang);
                    command.Parameters.AddWithValue("id_movie", entity.Id_Movie);
                    command.Parameters.AddWithValue("id_cinemaRoom", entity.Id_CinemaRoom);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(Diffusion entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Diffusion_Update";
                    command.Parameters.AddWithValue("id_diffusion", entity.Id_Diffusion);
                    command.Parameters.AddWithValue("diffusionDate", entity.DiffusionDate);
                    command.Parameters.AddWithValue("diffusionTime", entity.DiffusionTime);
                    command.Parameters.AddWithValue("audioLang", entity.AudioLang);
                    command.Parameters.AddWithValue("subTitleLang", entity.SubTitleLang);
                    command.Parameters.AddWithValue("id_movie", entity.Id_Movie);
                    command.Parameters.AddWithValue("id_cinemaRoom", entity.Id_CinemaRoom);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0) throw new ArgumentOutOfRangeException(nameof(entity.Id_Movie), $"L'identifiant {entity.Id_Movie} ne correspond à aucune valeur");
                }
            }
        }
    }
}
