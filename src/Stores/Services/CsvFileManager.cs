using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Stores.Models;

namespace Stores.Services
{
    public class CsvFileManager : ICsvFileManager
    {
        public IEnumerable<Store> GetFileData()
        {
            var storeData = File.ReadAllLines("StoreData.csv")
                   .Select(x => x.Split(','))
                   .Select(x => new Store
                    {
                        StoreNumber = int.Parse(x[0]),
                        StoreName = x[1],
                        StoreManagerName = String.IsNullOrEmpty(x[2]) ? "Unknown" : x[2],
                        OpeningTime = String.IsNullOrEmpty(x[3]) ? "Unknown" : x[3],
                        ClosingTime = String.IsNullOrEmpty(x[4]) ? "Unknown" : x[4]
                    });

            return storeData;
        }

        public void SaveFileData(IEnumerable<Store> stores)
        {
            throw new NotImplementedException();
        }
    }
}