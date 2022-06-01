/* using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Extensions;

namespace Catalog.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private List<Item> items = new()
        {
            new() {
                Id = Guid.NewGuid(), Name = "Silver Shield", Price = 12, DateCreated = DateTimeOffset.UtcNow
            },
            new() {
                Id = Guid.NewGuid(), Name = "Gold Shield", Price = 18,DateCreated = DateTimeOffset.UtcNow
            },
            new() {
                Id = Guid.NewGuid(), Name = "Platinum Shield", Price = 20, DateCreated = DateTimeOffset.UtcNow
            }
        };

        public IEnumerable<Item> GetItemsAsync()
        {
            return items;
        }

        public Item GetItemAsync(Guid id)
        {
            var item = items.Where(item => item.Id.Equals(id)).SingleOrDefault();
            return item;
        }

        public Item InsertItemAsync(Item item)
        {
            items.Add(item);
            return item;
        }

        public void UpdateItemAsync(Guid id, Item item)
        {
            var index = items.FindIndex((existingItem) => existingItem.Id.Equals(id));
            items[index] = item;
        }

        public void DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex((existingItem) => existingItem.Id.Equals(id));
            items.RemoveAt(index);
        }
    }
} */