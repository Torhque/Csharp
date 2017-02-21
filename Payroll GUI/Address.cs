using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_GUI
{
    class Address
    {
        //Create and use an Address class with the following properties:
        private string streetAddress    = "";
        private string apartmentNumber  = "";
        private string city             = "";
        private string state            = "";
        private string zip              = "";

        //Formal properties
        public string StreetAddress
        {
            get { return this.streetAddress; }
            set { this.streetAddress = value; }
        }

        public string ApartmentNumber
        {
            get { return apartmentNumber; }
            set { apartmentNumber = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }
        //Your Address class must have default and parameterized constructors
        public Address()
        {
            streetAddress       = "";
            apartmentNumber     = "";
            city                = "";
            state               = "";
            zip                 = "";
        }

        public Address(string initStreetAddress, string initApartmentNumber, string initCity, string initState, string initZip)
        {
            streetAddress       = initStreetAddress;
            apartmentNumber     = initApartmentNumber;
            city                = initCity;
            state               = initState;
            zip                 = initZip;
        }

        //Your Address class must override the ToString() method.
        public override string ToString()
        {
            return streetAddress + " " + apartmentNumber + "\n" + city + ", " + state + "  " + zip;
        }

    }
}
