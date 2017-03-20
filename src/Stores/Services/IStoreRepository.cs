using System.Collections.Generic;
using Stores.Models;

namespace Stores.Services
{
    public interface IStoreRepository
    {
        IEnumerable<Store> GetAllStores();

        Store GetStore(int storeNumber);

        bool AddStore(Store store);

        bool UpdateStore(int storeNumber, Store store);

        bool DeleteStore(int storeNumber);
    }
}