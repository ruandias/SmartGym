
using Flunt.Validations;
using System.Text.RegularExpressions;

namespace SmartGym.Domain.ValueTypes
{
    public struct CompanyName
    {
        private readonly string _value;
        public readonly Contract contract;

        private CompanyName(string value)
        {
            _value = value;
            contract = new Contract();
            Validate();
        }

        public override string ToString() =>
            _value;

        public static implicit operator CompanyName(string value) =>
            new CompanyName(value);

        private bool Validate()
        {

            if (string.IsNullOrWhiteSpace(_value))
                return AddNotification("Inform a valid companyName.");

            if (_value.Length < 10)
                return AddNotification("The name must have more than 10 chars.");

            if (!Regex.IsMatch(_value, (@"[^a-zA-Z0-9]")))
                return AddNotification("The companyName must not have any special char.");

            return true;
        }

        private bool AddNotification(string message)
        {
            contract.AddNotification(nameof(CompanyName), message);
            return false;
        }
    }

}
