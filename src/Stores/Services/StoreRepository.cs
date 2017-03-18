using System;
using System.Linq;
using System.Collections.Generic;
using Stores.Models;

namespace Stores.Services
{
    public class StoreRepository : IStoreRepository
    {
        private ICsvFileManager _csvFileManager;

        public StoreRepository(ICsvFileManager csvFileManager)
        {
            _csvFileManager = csvFileManager;
        }

        public IEnumerable<Store> GetAllStores()
        {
            var stores = _csvFileManager.GetFileData();
            var validStores = stores.Where(s => !String.IsNullOrEmpty(s.StoreName));
            return validStores;
        }

        public Store GetStore(int storeNumber)
        {
            var storeList = _csvFileManager.GetFileData();
            var store = storeList
                .Where(s => s.StoreNumber == storeNumber)
                .FirstOrDefault();
                
            return store;
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