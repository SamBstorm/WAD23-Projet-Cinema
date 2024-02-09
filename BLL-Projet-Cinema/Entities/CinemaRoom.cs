using DAL_Projet_Cinema.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Projet_Cinema.Entities
{
    public class CinemaRoom
    {
        private List<Diffusion> _diffusions ;

        public int Id_CinemaRoom { get; set; }
        public int SeatsCount { get; set; }
        public int Number { get; set; }
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }
        public bool Can3D { get; set; }
        public bool Can4DX { get; set; }
        public int Id_CinemaPlace { get; set; }
        public CinemaPlace CinemaPlace { get; set; }

        public Diffusion[] Diffusions { get { return _diffusions.ToArray(); } }

        private CinemaRoom() { 
            _diffusions = new List<Diffusion>();
        }
        public CinemaRoom(int seatsCount, int number, int screenWidth, int screenHeight, bool can3D, bool can4DX) : this()
        {
            SeatsCount = seatsCount;
            Number = number;
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
            Can3D = can3D;
            Can4DX = can4DX;
        }

        public CinemaRoom(int id_CinemaRoom, int seatsCount, int number, int screenWidth, int screenHeight, bool can3D, bool can4DX, int id_CinemaPlace) :this(seatsCount, number, screenWidth, screenHeight, can3D, can4DX)
        {
            Id_CinemaRoom = id_CinemaRoom;
            Id_CinemaPlace = id_CinemaPlace;
        }

        public CinemaRoom(int id_CinemaRoom, int seatsCount, int number, int screenWidth, int screenHeight, bool can3D, bool can4DX, CinemaPlace cinemaPlace) : this(seatsCount, number, screenWidth, screenHeight, can3D, can4DX)
        {
            Id_CinemaRoom = id_CinemaRoom;
            cinemaPlace.AddRoom(this);
        }

        public void AddDiffusion(Diffusion diffusion)
        {
            if (diffusion is null) throw new ArgumentNullException(nameof(diffusion), "Une diffusion ne peut pas être null.");
            if (diffusion.CinemaRoom is null) throw new ArgumentNullException(nameof(diffusion.CinemaRoom), "Une diffusion ne peut pas avoir de salle à null.");
            if (diffusion.CinemaRoom != this) throw new ArgumentException(nameof(diffusion.CinemaRoom), "La salle de la diffusion ne correspond pas.");
            _diffusions ??= new List<Diffusion>();
            _diffusions.Add(diffusion);
        }
    }
}
