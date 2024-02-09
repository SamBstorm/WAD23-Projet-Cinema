using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Projet_Cinema.Entities
{
    public class CinemaPlace
    {
        private List<CinemaRoom> _rooms;
        private List<Diffusion> _diffusions;

        public int Id_CinemaPlace { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public CinemaRoom? this[int roomNumber] {
            get
            {
                return _rooms.SingleOrDefault(r=>r.Number == roomNumber);
            }
        }
        public CinemaRoom[] Rooms { get { return _rooms.ToArray(); } }
        public Diffusion[] Diffusions { get { return _diffusions.ToArray(); } }
        private CinemaPlace()
        {
            _rooms = new List<CinemaRoom>();
            _diffusions = new List<Diffusion>();
        }
        public CinemaPlace(string name, string city, string street, string number) : this()
        {
            Name = name;
            City = city;
            Street = street;
            Number = number;
        }
        public CinemaPlace(int id_CinemaPlace, string name, string city, string street, string number) : this(name, city, street, number)
        {
            Id_CinemaPlace = id_CinemaPlace;
        }
        public void AddRoom(CinemaRoom newRoom)
        {
            if(newRoom is null) throw new ArgumentNullException(nameof(newRoom), "La nouvelle salle est null");
            if (newRoom.CinemaPlace != this && newRoom.CinemaPlace != null) throw new ArgumentException(nameof(newRoom.CinemaPlace), "Le Cinéma de la nouvelle salle ne correspond pas à celui-ci");
            newRoom.CinemaPlace = this;
            newRoom.Id_CinemaPlace = Id_CinemaPlace;
            _rooms.Add(newRoom);
        }
        public void AddDiffusion(Diffusion newDiffusion)
        {
            if (newDiffusion is null) throw new ArgumentNullException(nameof(newDiffusion), "La nouvelle diffusion est null");
            if (!Rooms.Contains(newDiffusion.CinemaRoom)) throw new ArgumentException(nameof(newDiffusion.CinemaRoom.CinemaPlace), "La sallede diffusion ne correspond pas à notre Cinéma");
            _diffusions.Add(newDiffusion);
        }
    }
}
