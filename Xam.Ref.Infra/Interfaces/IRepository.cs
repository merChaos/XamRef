using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Ref.Models;

namespace Xam.Ref.Infra.Interfaces
{
    public interface IRepository<T> where T : BaseModel, IDisposable
    {

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.String.</returns>
        string Save(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Update(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Delete(T entity);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        T GetById(int id);


        /// <summary>
        /// Saves all.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool SaveAll(IEnumerable<T> entities);

        /// <summary>
        /// Updates all.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool UpdateAll(IEnumerable<T> entities);

        /// <summary>
        /// Deletes all.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool DeleteAll();

        /// <summary>
        /// Drop the table
        /// </summary>
        /// <returns></returns>
        bool DropTable();

        /// <summary>
        /// Create table
        /// </summary>
        /// <returns></returns>
        bool CreateTable();

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Ifs the exists.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool IfExists(T entity);

        void BeginTransaction();

        void CommitTransaction();

    }
}
