using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_Projet_Cinema.Models
{
    public class CinemaPlaceListItem
    {
        [ScaffoldColumn(false)]
        public int Id_CinemaPlace {  get; set; }
        [DisplayName("Cinema")]
        public string Name {  get; set; }
        [DisplayName("Ville")]
        public string City {  get; set; }
    }
}
