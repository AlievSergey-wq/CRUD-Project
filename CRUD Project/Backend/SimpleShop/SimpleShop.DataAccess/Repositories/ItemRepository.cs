using Microsoft.EntityFrameworkCore;
using SimpleShop.Core.models;
using SimpleShop.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.DataAccess.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public readonly SimpleShopDBContext _context;

        public ItemRepository(SimpleShopDBContext context)
        {
            _context = context;
        }
        public async Task<List<Item>> Get()
        {
            var itemEntities = await _context.Items
                .AsNoTracking()
                .ToListAsync();
            var Items = itemEntities
                .Select(i => Item.Create(i.Id, i.Title, i.Description, i.Price).Item)
                .ToList(); return Items;
        }
        public async Task<Guid> Create(Item item)
        {
            var itemEntity = new ItemEntity
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                Price = item.Price,
            };
            await _context.Items.AddAsync(itemEntity);
            await _context.SaveChangesAsync();

            return itemEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string description, float price)
        {
            await _context.Items
                .Where(i => i.Id == id)
                .ExecuteUpdateAsync(c => c
                    .SetProperty(i => i.Title, i => title)
                    .SetProperty(i => i.Description, i => description)
                    .SetProperty(i => i.Price, i => price));
            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Items
                .Where(i => i.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }

    }
}
