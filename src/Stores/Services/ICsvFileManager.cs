using System.Collections.Generic;
using Stores.Models;

namespace Stores.Services
{
    public interface ICsvFileManager
    {
        IEnumerable<Store> GetFileContent();

        void SaveFileContent(IEnumerable<Store> stores);
    }
}