namespace Common.Responses.ErrorResponse
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; } = null!;
        public IEnumerable<Error>? Errors { get; set; }
    }
}
