namespace LibrarrySystem.DAL
{
    public class DbContext
    {
        public string ConString(string _config)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var config = builder.Build();
            string consfig = config.GetConnectionString(_config);
            return consfig;
        }
    }
}
