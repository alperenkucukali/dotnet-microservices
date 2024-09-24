using Customer.Domain.Common;

namespace Customer.Domain.Entities
{
    public class Customer : EntityBase
    {
        public Customer()
        {

        }

        public Customer(Guid id, string email, string firstName, string lastName)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
