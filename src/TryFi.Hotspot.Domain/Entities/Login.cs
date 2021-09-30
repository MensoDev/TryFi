using TryFi.Kernel.Domain.DomainObjects;

namespace TryFi.Hotspot.Domain.Entities
{
    public class Login : Entity
    {
        public Login(string userName, string password, string macAddress, Subscription subscription)
        {
            UserName = userName;
            Password = password;
            MacAddress = macAddress;
            Subscription = subscription;
            SubscriptionId = subscription is null ? Guid.Empty : subscription.Id;

            Validate();
        }

        // EF Compability
        protected Login()
        {}


        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string MacAddress { get; set; }

        public Subscription Subscription { get; private set; }
        public Guid SubscriptionId { get; private set; }

        public override void Validate()
        {
            AssertionConcern.NotEmpty(UserName, "UserName is Required");
            AssertionConcern.MinLength(UserName, 6, "The UserName must be at least four characters");

            AssertionConcern.NotEmpty(Password, "Password is Required");
            AssertionConcern.MinLength(Password, 6, "The Password must  be at least four characteres");

            AssertionConcern.NotEmpty(MacAddress,"MacAddress is required");
            AssertionConcern.HasMacAddress(MacAddress, "Mac Address is invalid");

            AssertionConcern.NotNull(Subscription, "Subscription is required");
            AssertionConcern.NotEmpty(SubscriptionId, "SubscriptionId is required");
        }
    }
}
