using System.Collections.Generic;
using Stores.Models;

namespace Stores.Services
{
    public interface ICsvFileManager
    {
        IEnumerable<Store> GetFileData();

        void SaveFileData(IEnumerable<Store> stores);
    }
}