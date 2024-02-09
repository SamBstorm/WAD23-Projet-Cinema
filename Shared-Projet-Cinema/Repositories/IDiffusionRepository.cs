using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Projet_Cinema.Repositories
{
    public interface IDiffusionRepository<TEntity> : ICRUDRepository<TEntity, int>
    {
        IEnumerable<TEntity> GetByCinemaPlace(int id_cinemaPlace);
        IEnumerable<TEntity> GetByMovie(int id_movie);
        IEnumerable<TEntity> GetByDate(DateTime diffusionDate);
    }
}
