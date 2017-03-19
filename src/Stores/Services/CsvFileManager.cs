using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Stores.Models;

namespace Stores.Services
{
    public class CsvFileManager : ICsvFileManager
    {
        private string _dataFile = "StoreData.csv";

        public IEnumerable<Store> GetFileData()
        {
            var storeData = File.ReadAllLines( _dataFile)
                   .Select(s => s.Split(','))
                   .Select(s => new Store
                    {
                        StoreNumber = int.Parse(s[0]),
                        StoreName = s[1],
                        StoreManagerName = String.IsNullOrEmpty(s[2]) ? "Unknown" : s[2],
                        OpeningTime = String.IsNullOrEmpty(s[3]) ? "Unknown" : s[3],
                        ClosingTime = String.IsNullOrEmpty(s[4]) ? "Unknown" : s[4]
                    });

            return storeData;
        }

        public void SaveFileData(IEnumerable<Store> stores)
        {
            var formattedStores = stores
                .Select(s => $"{s.StoreNumber},{s.StoreName ?? ""},{s.StoreManagerName ?? ""},{s.OpeningTime ?? ""},{s.ClosingTime ?? ""}");

            File.WriteAllLines(_dataFile, formattedStores);
        }
    }
}