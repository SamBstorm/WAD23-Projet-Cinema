using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Projet_Cinema.Entities
{
    public class Movie
    {
        private List<Diffusion> _diffusions;
        public int Id_Movie { get; set; }
        public string Title { get; set; }
        public string? SubTitle { get; set; }
        public short ReleaseYear { get; set; }
        public string Synopsis { get; set; }
        public string PosterUrl { get; set; }
        public int Duration { get; set; }
        public Diffusion[] Diffusions { get { 
            return _diffusions.ToArray();
            } 
        }
        private Movie()
        {
            _diffusions = new List<Diffusion>();
        }
        public Movie(string title, string? subTitle, short releaseYear, string synopsis, string posterUrl, int duration) : this()
        {
            Title = title;
            SubTitle = subTitle;
            ReleaseYear = releaseYear;
            Synopsis = synopsis;
            PosterUrl = posterUrl;
            Duration = duration;
        }
        public Movie(int id_Movie, string title, string? subTitle, short releaseYear, string synopsis, string posterUrl, int duration) : this(title, subTitle, releaseYear, synopsis, posterUrl, duration)
        {
            Id_Movie = id_Movie;
        }

        public void AddDiffusion(Diffusion diffusion)
        {
            if (diffusion is null) throw new ArgumentNullException(nameof(diffusion),"Une diffusion ne peut pas être null.");
            if (diffusion.Movie is null) throw new ArgumentNullException(nameof(diffusion.Movie), "Une diffusion ne peut pas avoir de film à null.");
            if (diffusion.Movie != this) throw new ArgumentException(nameof(diffusion.Movie), "Le film de la diffusion ne correspond pas.");
            _diffusions.Add(diffusion);
        }
    }
}
