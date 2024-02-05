using DAL_Projet_Cinema.Entities;
using DAL_Projet_Cinema.Mappers;
using Microsoft.Extensions.Configuration;
using Shared_Projet_Cinema.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Projet_Cinema.Services
{
    public class CinemaPlaceService : BaseService, ICinemaPlaceRepository<CinemaPlace>
    {
        public CinemaPlaceService(IConfiguration configuration) : base(configuration, "projet-cinema")
        {}

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_CinemaPlace_Delete";
                    command.Parameters.AddWithValue("id_cinemaPlace", id);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0) throw new ArgumentOutOfRangeException(nameof(id),$"L'identifiant {id} ne correspond à aucune valeur");
                }
            }
        }

        public IEnumerable<CinemaPlace> Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_CinemaPlace_GetAll";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToCinemaPlace();
                        }
                    }
                }
            }
        }

        public CinemaPlace Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_CinemaPlace_GetById";
                    command.Parameters.AddWithValue("id_cinemaPlace", id);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) return reader.ToCinemaPlace();
                        throw new ArgumentOutOfRangeException(nameof(id), $"L'identifiant {id} ne correspond à aucune valeur");
                    }
                }
            }
        }

        public int Insert(CinemaPlace entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_CinemaPlace_Insert";
                    command.Parameters.AddWithValue("name", entity.Name);
                    command.Parameters.AddWithValue("city", entity.City);
                    command.Parameters.AddWithValue("street", entity.Street);
                    command.Parameters.AddWithValue("number", entity.Number);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(CinemaPlace entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_CinemaPlace_Update";
                    command.Parameters.AddWithValue("id_cinemaPlace", entity.Id_CinemaPlace);
                    command.Parameters.AddWithValue("name", entity.Name);
                    command.Parameters.AddWithValue("city", entity.City);
                    command.Parameters.AddWithValue("street", entity.Street);
                    command.Parameters.AddWithValue("number", entity.Number);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0) throw new ArgumentOutOfRangeException(nameof(entity.Id_CinemaPlace), $"L'identifiant {entity.Id_CinemaPlace} ne correspond à aucune valeur");
                }
            }
        }
    }
}
