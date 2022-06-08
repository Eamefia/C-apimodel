using Scycare.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scycare.Apis.Models
{
    public class ItemRepository : IItemRepository   
    {
        private readonly ItemContext _itemContext;

        public ItemRepository(ItemContext itemContext)
        {
           _itemContext = itemContext;
        }

        public async Task<IEnumerable<ItemModel>> GetAllItemsAsync()
        {
            return await _itemContext.Items.ToListAsync();
        }

        public async Task<ItemModel> InsertItemAsync(ItemModel itemModel)
        {
            await _itemContext.Items.AddAsync(itemModel);
            await _itemContext.SaveChangesAsync();
            return itemModel;
        }

        public async Task<ItemModel> GetItemAsync(Guid Id)
        {
            ItemModel itemModel = await _itemContext.Items.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return itemModel;
        }

        public async Task DeleteAsync(Guid Id)
        {
            ItemModel itemModel = await _itemContext.Items.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            
            
                _itemContext.Remove(itemModel);
                await _itemContext.SaveChangesAsync();
            

        }

        public async Task<bool> UpdateItemAsync(ItemModel itemModel)
        {
            _itemContext.Items.Update(itemModel);
            await _itemContext.SaveChangesAsync();
            return true;
        }
    }
}
