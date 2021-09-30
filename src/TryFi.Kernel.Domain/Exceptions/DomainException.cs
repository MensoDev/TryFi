using System.Reflection;

namespace TryFi.Kernel.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException()
        { }

        public DomainException(string message) : base(message)
        { }

        public DomainException(string message, PropertyInfo propertyInfo) : base(message)
        {
            Property = propertyInfo;
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        { }


        public PropertyInfo Property { get; private set; }
    }
}
