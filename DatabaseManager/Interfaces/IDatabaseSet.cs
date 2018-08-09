using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager.Interfaces
{
    public interface IDatabaseSet<TEntity> : IQueryable<TEntity>, IEnumerable<TEntity>, IQueryable, IEnumerable, IDbSet<TEntity> where TEntity : class
    {
    }
}
