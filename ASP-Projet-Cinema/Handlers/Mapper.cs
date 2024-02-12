using ASP_Projet_Cinema.Models;
using BLL_Projet_Cinema.Entities;

namespace ASP_Projet_Cinema.Handlers
{
    public static class Mapper
    {
        #region CinemaPlace

        public static CinemaPlaceListItem ToListItem(this CinemaPlace entity)
        {
            if (entity is null) return null;
            return new CinemaPlaceListItem
            {
                Id_CinemaPlace = entity.Id_CinemaPlace,
                Name = entity.Name,
                City = entity.City
            };
        }

        public static CinemaPlaceDetails ToDetails(this CinemaPlace entity)
        {
            if (entity is null) return null;
            return new CinemaPlaceDetails
            {
                Id_CinemaPlace = entity.Id_CinemaPlace,
                Name = entity.Name,
                City = entity.City,
                Street = entity.Street,
                Number = entity.Number
            };
        }

        public static CinemaPlace ToBLL(this CinemaPlaceCreateForm entity)
        {
            if (entity is null) return null;
            return new CinemaPlace(
                entity.Name,
                entity.City,
                entity.Street,
                entity.Number);
        }

        #endregion
        #region Movie

        public static MovieListItem ToListItem(this Movie entity)
        {
            if (entity is null) return null;
            return new MovieListItem
            {
                Id_Movie = entity.Id_Movie,
                Title = entity.Title,
                SubTitle = entity.SubTitle,
                ShortSynopsis = ((entity.Synopsis.IndexOf('.') > 64) ? entity.Synopsis.Substring(0, 64): entity.Synopsis.Substring(0,entity.Synopsis.IndexOf('.'))) + " ...",
                PosterUrl = entity.PosterUrl
            };
        }

        public static MovieDetails ToDetails(this Movie entity)
        {
            if (entity is null) return null;
            return new MovieDetails
            {
                Id_Movie = entity.Id_Movie,
                Title = entity.Title,
                SubTitle = entity.SubTitle,
                ReleaseYear = entity.ReleaseYear,
                Synopsis = entity.Synopsis,
                PosterUrl = entity.PosterUrl,
                Duration = entity.Duration
            };
        }


        public static MovieEditForm ToEditForm(this Movie entity)
        {
            if (entity is null) return null;
            return new MovieEditForm
            {
                Id_Movie = entity.Id_Movie,
                Title = entity.Title,
                SubTitle = entity.SubTitle,
                ReleaseYear = entity.ReleaseYear,
                Synopsis = entity.Synopsis,
                PosterUrl = entity.PosterUrl,
                Duration = entity.Duration
            };
        }

        public static Movie ToBLL(this MovieCreateForm entity)
        {
            if (entity is null) return null;
            return new Movie(
                entity.Title,
                entity.SubTitle,
                entity.ReleaseYear,
                entity.Synopsis,
                entity.Poster.FileName,
                entity.Duration
            );
        }

        public static Movie ToBLL(this MovieEditForm entity)
        {
            if (entity is null) return null;
            return new Movie(
                entity.Title,
                entity.SubTitle,
                entity.ReleaseYear,
                entity.Synopsis,
                entity.Poster.FileName,
                entity.Duration
            );
        }

        #endregion
    }
}
