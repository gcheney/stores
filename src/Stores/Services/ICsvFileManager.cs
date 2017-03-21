using System.Collections.Generic;
using Stores.Models;

namespace Stores.Services
{
    public interface ICsvFileManager
    {
        /// <summary>
		/// Retrieves an IEnumerable<Store> of store data contained in a CSV file
		/// </summary>
		/// <returns>
		/// IEnumerable<Store> of store data
		/// </returns>
        IEnumerable<Store> GetFileData();

        /// <summary>
		/// Writes the provided IEnumerable<Store> store data to a CSV file, one element per line
		/// </summary>
		/// <param name="stores">The store data to write</param>
        void SaveFileData(IEnumerable<Store> stores);
    }
}