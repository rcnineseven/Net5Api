using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using net5api.DbSettings;
using net5api.Entities;

namespace net5api.Repositories
{
    public class DbRepository : IInMemItemsRepo
    {
        private IMySqlSettings _mySqlSettings;
        public DbRepository(IMySqlSettings mySqlSettings)
        {
            _mySqlSettings = mySqlSettings;
        }

        public void CreateItem(Item item)
        {
            /////shouldnt be in main
            MySqlConnection conn;
            try
            {
                 conn = new();
                 conn.ConnectionString = _mySqlSettings.connectionString;
                 conn.Open();
                 MySqlCommand comm = new()
                 {
                        CommandText = "INSERT INTO TEST.Items (ItemId,Name,Price) VALUES (@ItemId,@Name,@Price)",
                        Connection = conn
                 };
                 comm.Parameters.AddWithValue("@ItemId", item.Id);
                 comm.Parameters.AddWithValue("@Name", item.Name);
                 comm.Parameters.AddWithValue("@Price", item.Price);
                 comm.ExecuteNonQuery();
                 conn.Close();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("MYSQL WRONG");
            }
            
        }

        public void DeleteItem(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid guid)
        {
            throw new NotImplementedException();
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
