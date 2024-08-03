namespace TestAppAngularCountry.Server.DataTransferObjects
{
    public class ErrorResponseDto
    {
        public bool IsError { get; set; } = true;
        public IEnumerable<string>? Errors { get; set; }
    }
}
