namespace TestAppAngularCountry.Server.Configuration
{
    public class ConnectionOptions
    {
        public const string ConnectionStrings = "ConnectionStrings";

        public string PostgreSQL { get; set; } = String.Empty;
        public string SQLite { get; set; } = String.Empty;
    }
}
