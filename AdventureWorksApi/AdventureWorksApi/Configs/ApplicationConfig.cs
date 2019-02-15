namespace AdventureWorksApi.Configs
{
    public class ApplicationConfig
    {
        public LoggingConfig Logging { get; set; }
        public string DatabaseConnectionString { get; set; }
        public string ServiceBusConnectionString { get; set; }
        public string AllowedHosts { get; set; }
    }
}
