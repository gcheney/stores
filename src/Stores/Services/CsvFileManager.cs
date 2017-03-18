using System;
using System.Collections.Generic;
using Stores.Models;

namespace Stores.Services
{
    public class CsvFileManager : ICsvFileManager
    {
        public IEnumerable<Store> GetFileContent()
        {
            throw new NotImplementedException();
        }

        public void SaveFileContent(IEnumerable<Store> stores)
        {
            throw new NotImplementedException();
        }
    }
}