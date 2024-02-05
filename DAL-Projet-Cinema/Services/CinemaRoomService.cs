using DAL_Projet_Cinema.Entities;
using Microsoft.Extensions.Configuration;
using Shared_Projet_Cinema.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Projet_Cinema.Mappers;

namespace DAL_Projet_Cinema.Services
{
    public class CinemaRoomService : BaseService, ICinemaRoomRepository<CinemaRoom>
    {
        public CinemaRoomService(IConfiguration configuration) : base(configuration, "projet-cinema")
        {
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_CinemaRoom_Delete";
                    command.Parameters.AddWithValue("id_cinemaRoom", id);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0) throw new ArgumentOutOfRangeException(nameof(id), $"L'identifiant {id} ne correspond à aucune valeur");
                }
            }
        }

        public IEnumerable<CinemaRoom> Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_CinemaRoom_GetAll";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToCinemaRoom();
                        }
                    }
                }
            }
        }

        public CinemaRoom Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_CinemaRoom_GetById";
                    command.Parameters.AddWithValue("id_cinemaRoom", id);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) return reader.ToCinemaRoom();
                        throw new ArgumentOutOfRangeException(nameof(id), $"L'identifiant {id} ne correspond à aucune valeur");
                    }
                }
            }
        }

        public int Insert(CinemaRoom entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_CinemaRoom_Insert";
                    command.Parameters.AddWithValue("seatsCount", entity.SeatsCount);
                    command.Parameters.AddWithValue("number", entity.Number);
                    command.Parameters.AddWithValue("screenWidth", entity.ScreenWidth);
                    command.Parameters.AddWithValue("screenHeight", entity.ScreenHeight);
                    command.Parameters.AddWithValue("can3D", entity.Can3D);
                    command.Parameters.AddWithValue("can4DX", entity.Can4DX);
                    command.Parameters.AddWithValue("id_cinemaPlace", entity.Id_CinemaPlace);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(CinemaRoom entity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_CinemaRoom_Update";
                    command.Parameters.AddWithValue("id_cinemaRoom", entity.Id_CinemaRoom);
                    command.Parameters.AddWithValue("seatsCount", entity.SeatsCount);
                    command.Parameters.AddWithValue("number", entity.Number);
                    command.Parameters.AddWithValue("screenWidth", entity.ScreenWidth);
                    command.Parameters.AddWithValue("screenHeight", entity.ScreenHeight);
                    command.Parameters.AddWithValue("can3D", entity.Can3D);
                    command.Parameters.AddWithValue("can4DX", entity.Can4DX);
                    command.Parameters.AddWithValue("id_cinemaPlace", entity.Id_CinemaPlace);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    if (command.ExecuteNonQuery() <= 0) throw new ArgumentOutOfRangeException(nameof(entity.Id_CinemaRoom), $"L'identifiant {entity.Id_CinemaRoom} ne correspond à aucune valeur");
                }
            }
        }
    }
}
