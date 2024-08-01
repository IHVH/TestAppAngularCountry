namespace TestAppAngularCountry.Server.Exceptions
{
    [Serializable]
    public class ConfigurationMissingException : ApplicationException
    {
        public ConfigurationMissingException(string message) : base(message) { }
    }
}
