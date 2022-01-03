using System;
namespace net5api.DbSettings
{
    public class MySqlSettings : IMySqlSettings
    {
        public MySqlSettings()
        {
        }

        public string endpoint { get; set; }
        public int port { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string connectionString { get { return $"server={endpoint};uid={user};pwd={password};database=TEST"; } }
    }
}
