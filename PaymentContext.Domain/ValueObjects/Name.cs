using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "O nome deve conter pelo menos 3 caracteres")
                .HasMinLen(LastName, 3, "Name.LastName", "O sobrenome deve conter pelo menos 3 caracteres")
            );

            if (string.IsNullOrEmpty(FirstName))
                AddNotification("Name.FirstName", "Nome inválido");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}