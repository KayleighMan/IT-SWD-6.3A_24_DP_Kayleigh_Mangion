namespace LocationMicroservice.Models
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string LocationCollectionName { get; set; }
    }
}
