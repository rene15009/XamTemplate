using System.Collections.Generic;
using System.Threading.Tasks;
using Xam.Template.Samples.Models;

namespace Xam.Template.Samples.Services
{
    public interface IMockDataStore
    {
        Task<bool> AddItemAsync(Item item);
        Task<bool> DeleteItemAsync(string id);
        Task<Item> GetItemAsync(string id);
        Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false);
        Task<bool> UpdateItemAsync(Item item);
    }
}