using DAL = DAL_Projet_Cinema.Entities;
using Shared_Projet_Cinema.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_Projet_Cinema.Entities;
using BLL_Projet_Cinema.Mappers;

namespace BLL_Projet_Cinema.Services
{
    public class CinemaPlaceService : ICinemaPlaceRepository<CinemaPlace>
    {
        private readonly ICinemaPlaceRepository<DAL.CinemaPlace> _repository;
        public CinemaPlaceService(ICinemaPlaceRepository<DAL.CinemaPlace> repository)
        {
            _repository = repository;
        }
        public IEnumerable<CinemaPlace> Get()
        {
            return _repository.Get().Select(d => d.ToBLL());
        }

        public CinemaPlace Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public int Insert(CinemaPlace entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public void Update(CinemaPlace entity)
        {
            _repository.Update(entity.ToDAL());
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

    }
}
