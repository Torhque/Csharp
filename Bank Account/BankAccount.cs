using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Project
{
    class BankAccount
    {
        // I chose decimal as the data type because it is geared for deaing with currency
        private decimal balance = -1.00m;
        private decimal interestRate = -1.00m;

        // Formal properties
        public decimal theBalance
        {
            get { return this.balance; }
            set { balance = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
        }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            set { interestRate = value; }
        }

        // Default constructor (which initializes all data members to valid values)
        public BankAccount()
        {
            balance = -1.00m;
            interestRate = -1.00m;
        }

        // Paramaterized constructor
        public BankAccount(decimal initBalance, decimal initInterestRate)
        {
            balance = initBalance;
            interestRate = initInterestRate;
        }
    }
}
