using FluentValidation.Results;
using MediatR;
using TryFi.Kernel.Domain.DomainObjects;

namespace TryFi.Kernel.Domain.Messages
{
    public abstract class Command : IRequest<bool>
    {
        public string MessageType { get; private set; }
        public DateTime Timestamp { get; private set; }

        public ValidationResult ValidationResult { get; protected set; }

        public Command()
        {
            MessageType = GetType().Name;
            Timestamp = DateTime.Now;
        }

        public virtual bool IsValid()
        {
            AssertionConcern.ThrowException("Implement Command.IsValid Method, Method is Required");
            return false;
        }

    }
}
