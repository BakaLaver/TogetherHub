

namespace Domain.Exeptions
{
    public class DomainException:Exception
    {
        public DomainException(string message) : base($"Domain exception: ({message}).") { }
    }
}
