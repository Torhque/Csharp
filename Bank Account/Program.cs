using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Project
{
    class Program
    {
        // Create an enum for each of the menu choices for later use in a switch-break.
        enum MenuChoices
        {
            NONE            = 0,
            DEPOSIT         = 1,
            WITHDRAW        = 2,
            APPLY_INTEREST  = 3,
            EXIT_PROGRAM    = 4
        }

        static void Main(string[] args)
        {
            MenuChoices nextCommand = MenuChoices.NONE;
            BankAccount theBankAccount = new BankAccount();

            while (theBankAccount.Balance < 0)
            {
                try
                {
                    theBankAccount.theBalance = setInitialBalance();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine("NEW BALANCE: " + theBankAccount.Balance + "\n");

            while (theBankAccount.InterestRate < 0)
            {
                try
                {
                    theBankAccount.InterestRate = setInitialInterestRate();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            while (nextCommand != MenuChoices.EXIT_PROGRAM)
            {
                // I chose string as the data type because it works best with prompting user input
                string userSelection = "";
                userSelection = getMenuChoice();

                // Prompt the use for a command
                nextCommand = getSelectionFromMenuChoice(userSelection);

                // Add deposit amount to the balance if user selects choice 1
                if (nextCommand == MenuChoices.DEPOSIT)
                {
                    theBankAccount.theBalance += Deposit();

                    Console.WriteLine();

                    // Display the new balance
                    Console.WriteLine("NEW BALANCE: " + theBankAccount.Balance + "\n");
                }
                // Subtract withdrawal amount from the balance if user selects choice 2
                if (nextCommand == MenuChoices.WITHDRAW)
                {
                    theBankAccount.theBalance = Withdrawal(theBankAccount.Balance);

                    Console.WriteLine();

                    // Display the new balance
                    Console.WriteLine("NEW BALANCE: " + theBankAccount.Balance + "\n");
                }

                if (nextCommand == MenuChoices.APPLY_INTEREST)
                {
                    theBankAccount.theBalance = ApplyInterest(theBankAccount.Balance, theBankAccount.InterestRate);

                    // Display the new balance
                    Console.WriteLine("NEW BALANCE: " + theBankAccount.Balance + "\n");
                }
            }
        }

        // Method for setting the initial balance
        public static decimal setInitialBalance()
        {
            // I chose decimal as the data type because it is geared for deaing with currency
            decimal initialBalance = -1.00m;

            while (initialBalance < 0)
            {
                // Prompt the user for an initial balance amount
                Console.Write("Enter your initial balance amount: ");
                initialBalance = decimal.Parse(Console.ReadLine());

                // Check to see if the value entered is negative
                if (initialBalance < 0)
                {
                    Console.WriteLine("Balance cannot be negative!");
                    Console.WriteLine();
                }
            }

            return initialBalance;
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@ PHIL @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // On the final project page you mention TWO different values for what
        //      the interest rate could be. At the beginning you state 0% - 100%,
        //      and at the end you say 0% - 1%. I chose to go with the 0% - 100%
        // @@@@@@@@@@@@@@@@@@@@@@@@@@ PHIL @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // Method for setting the initial interest rate
        public static decimal setInitialInterestRate()
        {
            // I chose decimal as the data type because it is geared for deaing with currency
            decimal initialInterestRate = -1.00m;

            while (initialInterestRate < 0 || initialInterestRate > 1)
            {
                // Prompt the user for an initial balance amount
                Console.Write("Enter your initial interest value (between 0% and 1%): ");
                initialInterestRate = decimal.Parse(Console.ReadLine());

                // Check to see if the value entered is negative
                if (initialInterestRate < 0)
                {
                    Console.WriteLine("Interest rate cannot be negative!");
                    Console.WriteLine();
                }
            }

            return initialInterestRate;
        }

        // Method for displaying the menu with options
        public static void DisplayMenu()
        {
            Console.WriteLine("Please select an option below: \n" +
            "1. Make a deposit. \n" +
            "2. Make a withdrawal. \n" +
            "3. Apply interest.\n" +
            "4. Exit program.");
        }

        // Method for getting the user's choice
        private static string getMenuChoice()
        {
            string menuChoice = "";

            DisplayMenu();

            Console.Write("\nEnter number of choice --> ");
            menuChoice = Console.ReadLine();

            Console.WriteLine();

            return menuChoice;
        }

        // Check which selection the user made
        private static MenuChoices getSelectionFromMenuChoice(string menuChoice)
        {
            MenuChoices selection = MenuChoices.NONE;

            try
            {
                switch (menuChoice[0])
                {
                    case '1':
                        selection = MenuChoices.DEPOSIT;
                        break;
                    case '2':
                        selection = MenuChoices.WITHDRAW;
                        break;
                    case '3':
                        selection = MenuChoices.APPLY_INTEREST;
                        break;
                    case '4':
                        selection = MenuChoices.EXIT_PROGRAM;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            return selection;
        }

        // Method for getting the deposit amount
        public static decimal Deposit()
        {
            // I chose decimal as the data type because it is geared for deaing with currency
            decimal depositAmount = -1.00m;

            while (depositAmount < 0)
            {
                try
                {
                    Console.Write("Enter the amount you wish to deposit: ");
                    depositAmount = decimal.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                if (depositAmount < 0)
                    Console.WriteLine("Cannot enter negative value for deposit!");
            }

            return depositAmount;
        }

        // Method for getting the withdrawal amount
        public static decimal Withdrawal(decimal currentBalance)
        {
            decimal withdrawalAmount = -1.00m;

            while (withdrawalAmount < 0 || withdrawalAmount > currentBalance)
            {
                try
                {
                    Console.Write("Enter the amount you wish to withdraw: ");
                    withdrawalAmount = decimal.Parse(Console.ReadLine());

                    if (withdrawalAmount < 0 || withdrawalAmount > currentBalance)
                        Console.WriteLine("Withdrawal amount was negative or exceeded balance!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return currentBalance -= withdrawalAmount;
        }

        // Method for applying the interest value
        public static decimal ApplyInterest(decimal currentBalance, decimal anInterestRate)
        {
            decimal interestAmount = 0.00m;

            interestAmount = currentBalance * anInterestRate;

            return currentBalance += interestAmount;
        }
    }
}
