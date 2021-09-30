using TryFi.Kernel.Domain.Messages;

namespace TryFi.Kernel.Domain.DomainObjects
{
    public abstract class Entity
    {

        private List<Event> _events;

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        protected Entity(Guid id)
        {
            if (id != Guid.Empty)
                Id = id;
            else
                Id = Guid.NewGuid();
        }


        public Guid Id { get; protected set; }
        public IReadOnlyCollection<Event> Events => _events?.AsReadOnly();


        public void AddEvent(Event eventItem)
        {
            _events ??= new List<Event>();
            _events.Add(eventItem);
        }

        public void RemoveEvent(Event eventItem)
        {
            _events?.Remove(eventItem);
        }

        public void ClearEvents()
        {
            _events?.Clear();
        }


        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (compareTo is null) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        public abstract void Validate();

    }
}
