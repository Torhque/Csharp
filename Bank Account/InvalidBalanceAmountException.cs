using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Project
{
    class InvalidBalanceAmountException : Exception
    {
        public InvalidBalanceAmountException()
        {

        }

        public InvalidBalanceAmountException(string message)
        {

        }
    }
}
