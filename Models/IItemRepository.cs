using Scycare.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scycare.Apis.Models
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemModel>> GetAllItemsAsync();
        Task<ItemModel> InsertItemAsync(ItemModel itemModel);
        Task<ItemModel> GetItemAsync(Guid Id);
        Task DeleteAsync(Guid Id);
        Task<bool> UpdateItemAsync(ItemModel itemModel);
    }
}
