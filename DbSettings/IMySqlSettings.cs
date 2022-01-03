namespace net5api.DbSettings
{
    public interface IMySqlSettings
    {
        string endpoint { get; set; }
        int port { get; set; }
        string user { get; set; }
        string password { get; set; }
        string connectionString { get; }
    }
}