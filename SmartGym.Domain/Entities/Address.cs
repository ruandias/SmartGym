using SmartGym.Domain.Shared.Entities;

namespace SmartGym.Domain.Entities
{
    public class Address : Entity
    {
        public int Id { get; private set; }
        public string  Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

    }
}
