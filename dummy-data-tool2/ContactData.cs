using System;

namespace RandomContactGenerator
{
    internal class ContactData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }

        public ContactData(string firstName, string lastName, DateTime birthdate, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            PhoneNumber = phoneNumber;
        }
    }
}
