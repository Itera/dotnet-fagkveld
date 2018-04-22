namespace ConfigurationExample.Configuration
{
    public class DatabaseConfiguration
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ConnectionTimeout { get; set; }
    }
}