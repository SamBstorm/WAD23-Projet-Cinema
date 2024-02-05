using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_Projet_Cinema.Models
{
    public class MovieListItem
    {
        [ScaffoldColumn(false)]
        public int Id_Movie { get; set; }
        [DisplayName("Titre")]
        public string Title { get; set; }
        [DisplayName("Sous-titre")]
        public string? SubTitle { get; set; }
        [DisplayName("Synopsis")]
        public string ShortSynopsis { get; set; }
        [DisplayName("Affiche")]
        [DataType(DataType.ImageUrl)]
        public string PosterUrl { get; set; }
    }
}
