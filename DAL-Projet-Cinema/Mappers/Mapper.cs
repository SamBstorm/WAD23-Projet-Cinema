using DAL_Projet_Cinema.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Projet_Cinema.Mappers
{
    public static class Mapper
    {
        public static Movie ToMovie(this IDataRecord record)
        {
            if (record is null) return null;
            return new Movie
            {
                Id_Movie = (int)record[nameof(Movie.Id_Movie)],
                Title = (string)record[nameof(Movie.Title)],
                SubTitle = (record[nameof(Movie.SubTitle)] is DBNull) ? null : (string)record[nameof(Movie.SubTitle)],
                ReleaseYear = (short)record[nameof(Movie.ReleaseYear)],
                Synopsis = (string)record[nameof(Movie.Synopsis)],
                PosterUrl = (string)record[nameof(Movie.PosterUrl)],
                Duration = (int)record[nameof(Movie.Duration)]
            };
        }
        public static CinemaPlace ToCinemaPlace(this IDataRecord record)
        {
            if (record is null) return null;
            return new CinemaPlace
            {
                Id_CinemaPlace = (int)record[nameof(CinemaPlace.Id_CinemaPlace)],
                Name = (string)record[nameof(CinemaPlace.Name)],
                City = (string)record[nameof(CinemaPlace.City)],
                Street = (string)record[nameof(CinemaPlace.Street)],
                Number = (string)record[nameof(CinemaPlace.Number)]
            };
        }

        public static CinemaRoom ToCinemaRoom(this IDataRecord record)
        {
            if (record is null) return null;
            return new CinemaRoom
            {
                Id_CinemaRoom = (int)record[nameof(CinemaRoom.Id_CinemaRoom)],
                SeatsCount = (int)record[nameof(CinemaRoom.SeatsCount)],
                Number = (int)record[nameof(CinemaRoom.Number)],
                ScreenWidth = (int)record[nameof(CinemaRoom.ScreenWidth)],
                ScreenHeight = (int)record[nameof(CinemaRoom.ScreenHeight)],
                Can3D = (bool)record[nameof(CinemaRoom.Can3D)],
                Can4DX = (bool)record[nameof(CinemaRoom.Can4DX)],
                Id_CinemaPlace = (int)record[nameof(CinemaRoom.Id_CinemaPlace)]
            };
        }
    }
}
