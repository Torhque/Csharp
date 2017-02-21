using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_GUI
{
    //Your employee class must inherit from the person class
    class Employee : Person
    {
        private string jobTitle     = "";
        private float wage          = 0.0f;
        private float hoursWorked   = 0.0f;
        private bool onThePayroll   = false;

        //Formal properties
        public string JobTitle
        {
            get { return jobTitle; }
            set { jobTitle = value; }
        }

        public float Wage
        {
            get { return wage; }
            set 
            {
                if (wage < 0)
                    throw new Exception("Wage cannot be negative.");
                else
                    wage = value;
            }
        }

        public float HoursWorked
        {
            get { return hoursWorked; }
            set { hoursWorked = value; }
        }

        public bool OnThePayroll
        {
            get { return onThePayroll; }
            set { onThePayroll = value; }
        }

        //Your Employee class must also have a pay method that returns the employee’s pay 
        //based on his or her wage and hours worked.
        public float Pay(float hourlyWage, float numberOfHoursWorked)
        {
            float employeePayment = 0;

            employeePayment = hourlyWage * numberOfHoursWorked;

            return employeePayment;
        }

        //Your Employee class must have default and parameterized constructors
        public Employee()
        {
            jobTitle        = "";
            wage            = 0.0f;
            hoursWorked     = 0.0f;
            onThePayroll    = false;
        }

        public Employee(string initJobtitle, float initWage, float initHoursWorked, bool initOnThePayroll)
        {
            jobTitle        = initJobtitle;
            wage            = initWage;
            hoursWorked     = initHoursWorked;
            onThePayroll    = initOnThePayroll;
        }

        //Your Employee class must override the ToString() method.
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

    }
}
