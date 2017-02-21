using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    class Person
    {
        //Create and use a Person class:
        private string firstName = "";
        private string lastName = "";
        private string phoneNumber = "";
        //Your person class must also contain an instance of the address class.
        public Address personAddress = new Address();

        //Formal properties
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        //Your Person class must have default and parameterized constructors
        public Person()
        {
            firstName = "";
            lastName = "";
            phoneNumber = "";
        }
        
        public Person(string initFirstName, string initLastName, string initPhoneNumber)
        {
            firstName = initFirstName;
            lastName = initLastName;
            phoneNumber = initPhoneNumber;
        }

        //Your Person class must override the ToString() method.
        public override string ToString()
        {
 	         return firstName + " " + lastName + "\n" + phoneNumber + "\n";
        }
    }
}
