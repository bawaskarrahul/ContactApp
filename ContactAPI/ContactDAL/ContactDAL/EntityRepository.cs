using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Linq.Expressions;

namespace ContactDAL
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
       IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Attach(TEntity entity);
        void SaveChanges();
    }

    // public abstract class EntityRepository<C, T> : IGenericRepository<T>
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The context object for the database
        /// </summary>
        private ObjectContext _context;

        /// <summary>
        /// The IObjectSet that represents the current entity.
        /// </summary>
        private IObjectSet<TEntity> _objectSet;

        /// <summary>
        /// Initializes a new instance of the GenericRepository class
        /// </summary>
        /// <param name="context">The Entity Framework ObjectContext</param>
        public EntityRepository()
        {
            try
            {
                _context = new ContactsEntities();
                _objectSet = _context.CreateObjectSet<TEntity>();
            }
            catch(ApplicationException Ex)
            {
                string error = Ex.Message;
            }
        }
      
 
        /// <summary>
        /// Gets all records as an IEnumberable
        /// </summary>
        /// <returns>An IEnumberable object containing the results of the query</returns>
        public IEnumerable<TEntity> GetAll()
        {
             return _objectSet.AsEnumerable();
            
        }

        /// <summary>
        /// Deletes the specified entitiy
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _objectSet.DeleteObject(entity);
        }

        /// <summary>
        /// Adds the specified entity
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _objectSet.AddObject(entity);
        }

        /// <summary>
        /// Attaches the specified entity
        /// </summary>
        /// <param name="entity">Entity to attach</param>
        public void Attach(TEntity entity)
        {
            _objectSet.Attach(entity);
        }

        /// <summary>
        /// Saves all context changes
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase
        /// </summary>
        /// <param name="disposing">A boolean value indicating whether or not to dispose managed resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }

}