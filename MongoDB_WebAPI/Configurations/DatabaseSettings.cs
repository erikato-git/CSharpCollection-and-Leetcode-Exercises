namespace MongoDB_WebAPI.Configurations
{
    // Mapper-class: is used to map MongoDB-appsettings to an object used in the application
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null;
        public string DataBaseName { get; set; } = null;
        public string CollectionsName { get; set; } = null;
    }
}
