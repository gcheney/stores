using System;
using System.Collections.Generic;
using Stores.Models;

namespace Stores.Services
{
    public class StoreRepository : IStoreRepository
    {
        public IEnumerable<Store> GetStores()
        {
            throw new NotImplementedException();
        }

        public Store GetStore(int storeNumber)
        {
            throw new NotImplementedException();
        }

        public void AddStore(Store store)
        {
            throw new NotImplementedException();
        }

        public void UpdateStore(int storeNumber, Store store)
        {
            throw new NotImplementedException();
        }

        public void DeleteStore(int storeNumber)
        {
            throw new NotImplementedException();
        }
    }
}