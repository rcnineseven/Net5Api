using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using net5api.DbSettings;
using net5api.Entities;
using System.Linq;


namespace net5api.Repositories
{
    public class DbRepository : IInMemItemsRepo
    {
        private MySqlDbContext _mySqlContext;
        public DbRepository( MySqlDbContext context)
        {
            _mySqlContext = context;
        }

        public void CreateItem(Item item)
        {
            try {
            _mySqlContext.Items.Add(item);
            _mySqlContext.SaveChanges();
            }
            catch(Exception ex){
            Console.WriteLine(ex.Message);
            }
        }

        public void DeleteItem(Guid guid)
        {
            Item deleteItem = GetItem(guid);
            _mySqlContext.Items.Remove(deleteItem);
            _mySqlContext.SaveChanges();
           
        }

        public Item GetItem(Guid guid)
        {
           try{
           return _mySqlContext.Items.Where(x => x.ItemId == guid.ToString()).SingleOrDefault();
           }
           catch(Exception ex){
            return null;    
           }
        }

        public IEnumerable<Item> GetItems()
        {
            try{
            return _mySqlContext.Items;
            }
            catch(Exception ex){

            }
            return null;    
        }

        public void UpdateItem(Item item)
        {
           try{
           var updateItem = _mySqlContext.Items.SingleOrDefault(x=>x.ItemId ==item.ItemId);
           updateItem.Name = item.Name;
           updateItem.Price = item.Price;
           _mySqlContext.SaveChanges();
           }
           catch(Exception ex){

           }
            
        }
    }
}
