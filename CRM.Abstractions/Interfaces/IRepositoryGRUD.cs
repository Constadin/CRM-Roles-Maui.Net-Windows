using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Abstractions.Interfaces
{
    public interface IRepositoryGRUD<T> where T : class
    {
        /// <summary>
        /// Loads a list of all entities of type T from the database.
        /// This method retrieves all records of type T from the corresponding table.
        /// </summary>
        /// <returns>A list of entities of type T.</returns>
        List<T> LoadEntities();

        /// <summary>
        /// Saves a new entity of type T to the database.
        /// This method inserts the provided entity into the corresponding table.
        /// </summary>
        /// <param name="entity">The entity of type T to be saved.</param>
        void SaveEntity(T entity);

        /// <summary>
        /// Updates an existing entity of type T in the database.
        /// This method modifies the values of an entity in the database based on the provided entity.
        /// It assumes the entity contains an identifier (e.g., Id) for locating the existing record.
        /// </summary>
        /// <param name="entity">The entity of type T to be updated.</param>
        void UpdateEntity(T entity);

        /// <summary>
        /// Deletes an entity of type T from the database based on its Id.
        /// This method removes the record that matches the provided Id from the corresponding table.
        /// </summary>
        /// <param name="id">The identifier (Id) of the entity to be deleted.</param>
        void DeleteEntity(int id);
    }

}
