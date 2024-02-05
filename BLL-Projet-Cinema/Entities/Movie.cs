using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Projet_Cinema.Entities
{
    public class Movie
    {
        public int Id_Movie { get; set; }
        public string Title { get; set; }
        public string? SubTitle { get; set; }
        public short ReleaseYear { get; set; }
        public string Synopsis { get; set; }
        public string PosterUrl { get; set; }
        public int Duration { get; set; }
    }
}
