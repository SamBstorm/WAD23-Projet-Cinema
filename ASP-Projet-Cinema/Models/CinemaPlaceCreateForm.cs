using System.ComponentModel.DataAnnotations;

namespace ASP_Projet_Cinema.Models
{
    public class CinemaPlaceCreateForm
    {
        [Required(ErrorMessage = "Le nom du cinéma est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le nom du cinéma doit être composé de minimum 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le nom du cinéma doit être composé de maximum 64 caractères.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La ville du cinéma est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le ville du cinéma doit être composé de minimum 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le ville du cinéma doit être composé de maximum 64 caractères.")]
        public string City { get; set; }
        [Required(ErrorMessage = "La rue du cinéma est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le rue du cinéma doit être composé de minimum 2 caractères.")]
        [MaxLength(128, ErrorMessage = "Le rue du cinéma doit être composé de maximum 128 caractères.")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Le numéro du cinéma est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le numéro du cinéma doit être composé de minimum 2 caractères.")]
        [MaxLength(8, ErrorMessage = "Le numéro du cinéma doit être composé de maximum 8 caractères.")]
        public string Number { get; set; }
    }
}
