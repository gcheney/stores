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
            var storeList = _csvFileManager.GetStoreData();
            var validStores = storeList.Where(s => !string.IsNullOrEmpty(s.StoreName));
            return validStores;
        }

        public Store GetStore(int storeNumber)
        {
            var storeList = _csvFileManager.GetStoreData();
            var store = storeList
                .FirstOrDefault(s => s.StoreNumber == storeNumber && !string.IsNullOrEmpty(s.StoreName));

            return store;
        }

        public bool AddStore(Store store)
        {
            var storeList = _csvFileManager.GetStoreData().ToList();
            if (!storeList.Any(s => s.StoreNumber == store.StoreNumber))
            {
                storeList.Add(store);
                _csvFileManager.SaveStoreData(storeList);
                return true;
            }

            return false;
        }

        public bool UpdateStore(int storeNumber, Store store)
        {
            var storeList = _csvFileManager.GetStoreData().ToList();
            var storeToUpdate = storeList.FirstOrDefault(s => s.StoreNumber == storeNumber);
            if (storeToUpdate != null)
            {
                storeToUpdate.StoreName  = store.StoreName ?? storeToUpdate.StoreName;
                storeToUpdate.StoreManagerName = store.StoreManagerName ?? storeToUpdate.StoreManagerName;
                storeToUpdate.OpeningTime = store.OpeningTime ?? storeToUpdate.OpeningTime;
                storeToUpdate.ClosingTime = store.ClosingTime ?? storeToUpdate.ClosingTime;

                _csvFileManager.SaveStoreData(storeList);
                return true;
            }

            return false;
        }

        public bool DeleteStore(int storeNumber)
        {
            var storeList = _csvFileManager.GetStoreData().ToList();            
            var storeToRemove = storeList.SingleOrDefault( s => s.StoreNumber == storeNumber);
            if (storeToRemove != null)
            {
               var result = storeList.Remove(storeToRemove);
               _csvFileManager.SaveStoreData(storeList);
               return result;
            }

            return false;
        }
    }
}