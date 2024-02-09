using BLL_Projet_Cinema.Entities;
using DAL = DAL_Projet_Cinema.Entities;
using Shared_Projet_Cinema.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_Projet_Cinema.Mappers;

namespace BLL_Projet_Cinema.Services
{
    public class DiffusionService : IDiffusionRepository<Diffusion>
    {
        private readonly IDiffusionRepository<DAL.Diffusion> _repository;

        public DiffusionService(IDiffusionRepository<DAL.Diffusion> repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Diffusion> Get()
        {
            return _repository.Get().Select(d => d.ToBLL());
        }

        public Diffusion Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public IEnumerable<Diffusion> GetByCinemaPlace(int id_cinemaPlace)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Diffusion> GetByDate(DateTime diffusionDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Diffusion> GetByMovie(int id_movie)
        {
            throw new NotImplementedException();
        }

        public int Insert(Diffusion entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public void Update(Diffusion entity)
        {
            _repository.Update(entity.ToDAL());
        }
    }
}
