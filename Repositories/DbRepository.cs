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
       // private IMySqlSettings _mySqlSettings;
        private MySqlDbContext _mySqlContext;
        public DbRepository( MySqlDbContext context)
        {
           
            _mySqlContext = context;
        }

        public void CreateItem(Item item)
        {
            

            try {
            Console.WriteLine("1");
            _mySqlContext.Items.Add(item);
            _mySqlContext.SaveChanges();
            }
            catch(Exception ex){
            Console.WriteLine("DB INSERT FAILED");
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
           return _mySqlContext.Items.Where(x => x.ItemId == guid.ToString()).SingleOrDefault();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
