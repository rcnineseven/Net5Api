using net5api.Entities;
using System.Collections.Generic;
using System;
using net5api.Repositories;
using System.Linq;
namespace net5api.Repositories{

    public class InMemItemsRepo : IInMemItemsRepo
    {

        private readonly List<Item> items = new()
        {
            new Item
            {
                Id = Guid.NewGuid(),
                Name = "Choppa",
                Price = 9,
                CreatedDate = DateTime.Now
            },
            new Item
            {
                Id = Guid.NewGuid(),
                Name = "Member",
                Price = 10,
                CreatedDate = DateTimeOffset.UtcNow
            },
            new Item
            {
                Id = Guid.NewGuid(),
                Name = "Gang",
                Price = 911,
                CreatedDate = DateTime.UtcNow
            },

        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid guid)
        {
            return (from s in items select s).Where(s => s.Id == guid).SingleOrDefault();
        }

        public void CreateItem(Item item){
            items.Add(item);
        }

        public void DeleteItem(Guid guid){
           var index = items.FindIndex(x=>x.Id==guid);
           items.RemoveAt(index);

        }

        public void UpdateItem(Item item){
            var index = items.FindIndex(x=>x.Id == item.Id);
            items[index]=item;
            
        }



    }
}