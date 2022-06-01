using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IItemsRepository
    {
        Task<Item> GetItemAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item> InsertItemAsync(Item item);
        Task UpdateItemAsync(Guid id, Item item);
        Task DeleteItemAsync(Guid id);
    }
}