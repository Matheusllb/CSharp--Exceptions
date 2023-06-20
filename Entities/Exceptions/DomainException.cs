
namespace CustomExceptions.Entities.Exceptions
{
    public class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message) 
        {

        }
    }
}
