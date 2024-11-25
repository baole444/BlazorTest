namespace StaffManager
{
    public class ConfigLoader
    {
        private static IConfiguration _config;

        static ConfigLoader()
        {
            _config = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).
                Build();
        }

        public static IConfiguration GetConfiguration()
        {
            return _config;
        }
    }
}
