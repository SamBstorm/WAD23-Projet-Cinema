using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Projet_Cinema.Entities
{
    public class Diffusion
    {
        public int Id_Diffusion { get; set; }
        public DateTime DiffusionDateTime { get; set; }
        public Language AudioLang { get; set; }
        public Language? SubTitleLang { get; set; }
        public int Id_CinemaRoom { get; set; }
        public CinemaRoom CinemaRoom { get; set; }
        public int Id_Movie { get; set; }
        public Movie Movie { get; set; }

        private Diffusion(DateTime diffusionDateTime, Language audioLang, Language? subTitleLang)
        {
            DiffusionDateTime = diffusionDateTime;
            AudioLang = audioLang;
            SubTitleLang = subTitleLang;
        }
        public Diffusion(DateTime diffusionDateTime, Language audioLang, Language? subTitleLang, int id_CinemaRoom, int id_Movie) : this(diffusionDateTime, audioLang, subTitleLang)
        {
            Id_CinemaRoom = id_CinemaRoom;
            Id_Movie = id_Movie;
        }
        public Diffusion(int id_Diffusion, DateTime diffusionDateTime, Language audioLang, Language? subTitleLang, int id_CinemaRoom, int id_Movie) : this (diffusionDateTime, audioLang, subTitleLang, id_CinemaRoom, id_Movie)
        {
            Id_Diffusion = id_Diffusion;
        }

        public Diffusion(DateTime diffusionDateTime, Language audioLang, Language? subTitleLang, CinemaRoom cinemaRoom, Movie movie)
        {

            DiffusionDateTime = diffusionDateTime;
            AudioLang = audioLang;
            SubTitleLang = subTitleLang;
            CinemaRoom = cinemaRoom;
            Id_CinemaRoom = cinemaRoom.Id_CinemaRoom;
            Movie = movie;
            Id_Movie = movie.Id_Movie;
            movie.AddDiffusion(this);
            cinemaRoom.AddDiffusion(this);
        }

    }
}
