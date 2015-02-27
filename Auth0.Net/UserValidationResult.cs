namespace Auth0
{
    public class UserValidationResult
    {
        public bool IsValid { get; internal set; }

        public string Message { get; internal set; }
    }
}