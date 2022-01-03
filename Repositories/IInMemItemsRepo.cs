using net5api.Controllers;
using net5api.Entities;
using net5api.Repositories;
using System;
using System.Collections.Generic;


namespace net5api.Repositories{
    public interface IInMemItemsRepo
    {
        Item GetItem(Guid guid);
        IEnumerable<Item> GetItems();

        void CreateItem(Item item);
        void UpdateItem(Item item);

        void DeleteItem(Guid guid);

    }
}
