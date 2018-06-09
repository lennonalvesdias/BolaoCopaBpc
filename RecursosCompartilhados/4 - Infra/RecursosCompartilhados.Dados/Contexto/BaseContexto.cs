using MongoDB.Driver;
using System;

public class BaseContexto
{
    public static string ConnectionString { get; set; }
    public static string DatabaseName { get; set; }
    public static bool IsSSL { get; set; }

    public IMongoDatabase _database { get; }

    public BaseContexto()
    {
        try
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
            if (IsSSL)
            {
                settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
            }
            var mongoClient = new MongoClient(settings);
            _database = mongoClient.GetDatabase(DatabaseName);
        }
        catch (Exception ex)
        {
            throw new Exception("N�o foi poss�vel se conectar com o servidor.", ex);
        }
    }
}