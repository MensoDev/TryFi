using TryFi.Kernel.Domain.DomainObjects;

namespace TryFi.Hotspot.Domain.Entities
{
    public class Subscription : Entity, IAggregateRoot
    {

        public Subscription(Guid personId, Plan plan, Login login)
        {
            PersonId = personId;

            Plan = plan;
            PlanId = plan is null ? Guid.Empty : plan.Id;

            Login = login;
            LoginId = login is null ? Guid.Empty : login.Id;

            Validate();
        }

        //EF Compatibility
        protected Subscription()
        {}


        public Guid PersonId { get; private set; }

        public Plan Plan { get; private set; }
        public Guid PlanId { get; private set; }

        public Login Login { get; private set; }
        public Guid LoginId { get; private set; }

        public DateTime RegistrationDate { get; private set; }


        public override void Validate()
        {
            AssertionConcern.NotEmpty(PersonId, "PersonId id required");

            AssertionConcern.NotNull(Plan, "Plan is required");
            AssertionConcern.NotEmpty(PlanId, "PlanId is required");

            AssertionConcern.NotNull(Login, "Login is required");
            AssertionConcern.NotEmpty(LoginId, "LoginId is required");
        }
    }
}
