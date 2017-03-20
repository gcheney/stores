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
            var storeList = _csvFileManager.GetFileData();
            var validStores = storeList.Where(s => !String.IsNullOrEmpty(s.StoreName));
            return validStores;
        }

        public Store GetStore(int storeNumber)
        {
            var storeList = _csvFileManager.GetFileData();
            var store = storeList.FirstOrDefault(s => s.StoreNumber == storeNumber);
                
            return store;
        }

        public bool AddStore(Store store)
        {
            var storeList = _csvFileManager.GetFileData().ToList();
            if (!storeList.Any(s => s.StoreNumber == store.StoreNumber))
            {
                storeList.Add(store);
                _csvFileManager.SaveFileData(storeList);
                return true;
            }

            return false;
        }

        public bool UpdateStore(int storeNumber, Store store)
        {
            var storeList = _csvFileManager.GetFileData().ToList();
            var storeToUpdate = storeList.FirstOrDefault(s => s.StoreNumber == storeNumber);

            if (storeToUpdate != null)
            {
                storeToUpdate.StoreName  = store.StoreName ?? storeToUpdate.StoreName;
                storeToUpdate.StoreManagerName = store.StoreManagerName ?? storeToUpdate.StoreManagerName;
                storeToUpdate.OpeningTime = store.OpeningTime ?? storeToUpdate.OpeningTime;
                storeToUpdate.ClosingTime = store.ClosingTime ?? storeToUpdate.ClosingTime;

                _csvFileManager.SaveFileData(storeList);
                return true;
            }

            return false;
        }

        public void DeleteStore(int storeNumber)
        {
            throw new NotImplementedException();
        }
    }
}