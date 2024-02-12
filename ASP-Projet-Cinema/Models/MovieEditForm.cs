using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Projet_Cinema.Models
{
    public class MovieEditForm
    {
        [HiddenInput]
        [Required(ErrorMessage = "L'identifiant du film est obligatoire.")]
        public int Id_Movie {  get; set; }
        [DisplayName("Titre")]
        [Required(ErrorMessage = "Le titre du film est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le titre du film doit être composé de minimum 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le titre du film doit être composé de maximum 64 caractères.")]
        public string Title { get; set; }
        [DisplayName("Sous-titre")]
        [MinLength(2, ErrorMessage = "Le sous-titre du film doit être composé de minimum 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le sous-titre du film doit être composé de maximum 64 caractères.")]
        public string? SubTitle { get; set; }
        [DisplayName("Année de sortie")]
        [Required(ErrorMessage = "L'année de sortie du film est obligatoire.")]
        public short ReleaseYear { get; set; }
        [DisplayName("Synopsis")]
        [DataType(DataType.MultilineText)]
        [MinLength(2, ErrorMessage = "Le synopsis du film doit être composé de minimum 2 caractères.")]
        [MaxLength(8000, ErrorMessage = "Le synopsis du film doit être composé de maximum 8000 caractères.")]
        [Required(ErrorMessage = "Un synopsis du film est obligatoire.")]
        public string Synopsis { get; set; }
        [DisplayName("Affiche")]
        [Required(ErrorMessage = "Une affiche du film est obligatoire.")]
        public IFormFile Poster { get; set; }
        [ScaffoldColumn(false)]
        public string PosterUrl { get; set;}
        [DisplayName("Durée en minutes")]
        [Required(ErrorMessage = "La durée du film est obligatoire.")]
        public int Duration { get; set; }
    }
}
