using System.Collections.Generic;
using Stores.Models;

namespace Stores.Services
{
    public interface IStoreRepository
    {
        /// <summary>
		/// Retrieves an IEnumerable of all valid stores currently in the data store
		/// </summary>
		/// <returns>
		///  IEnumerable<Store> of all valid stores
		/// </returns>
        IEnumerable<Store> GetAllStores();

        /// <summary>
		/// Retrieves the Store with the specificed storeNumber, if it exist
		/// </summary>
		/// <param name="storeNumber">The storeNumber of the Store to retrieve</param>
		/// <returns>
		/// The Store object if it exist, null otherwise
		/// </returns>
        Store GetStore(int storeNumber);

        /// <summary>
		/// Adds the provided Store object to the data store
		/// </summary>
		/// <param name="store">The Store to add</param>
		/// <returns>
		/// True if the store was added, false otherwise
		/// </returns>
        bool AddStore(Store store);

        /// <summary>
		/// Updates the store with the specificed storeNumber with the data in the provided store object
		/// </summary>
		/// <param name="storeNumber">The storeNumber of the store to update</param>
        /// <param name="store">The store data to update</param>
		/// <returns>
		/// True if the Store was updated, false otherwise
		/// </returns>
        bool UpdateStore(int storeNumber, Store store);

        /// <summary>
		/// Removes the Store with the specified storeNumber
		/// </summary>
		/// <param name="storeNumber">The storeNumber of the Store to remove</param>
		/// <returns>
		/// True if the store was removed, false otherwise
		/// </returns>
        bool DeleteStore(int storeNumber);
    }
}