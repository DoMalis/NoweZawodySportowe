namespace ProjektZawody.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) :base(message)//dodac catcha w klasie middleware
        { }
    }
}
