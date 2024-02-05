using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Projet_Cinema.Repositories
{
    public interface IMovieRepository<TEntity> : ICRUDRepository<TEntity, int>
    {
    }
}
