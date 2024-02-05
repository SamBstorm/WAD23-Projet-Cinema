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
    public class MovieService : IMovieRepository<Movie>
    {
        private readonly IMovieRepository<DAL.Movie> _repository;
        public MovieService(IMovieRepository<DAL.Movie> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Movie> Get()
        {
            return _repository.Get().Select(d => d.ToBLL());
        }

        public Movie Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public int Insert(Movie entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public void Update(Movie entity)
        {
            _repository.Update(entity.ToDAL());
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

    }
}
