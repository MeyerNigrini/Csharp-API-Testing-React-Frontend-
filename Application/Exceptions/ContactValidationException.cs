namespace Services.Exceptions
{
    public class ContactValidationException : Exception
    {
        public ContactValidationException(string message) : base(message) { }
    }
}
