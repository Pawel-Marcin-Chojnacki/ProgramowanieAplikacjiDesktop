using DatabaseManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public class DatabaseSet<TEntity> : DbSet<TEntity> where TEntity : class
    {
    }
}
