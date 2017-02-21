using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    class Program
    {
        // Create an enum for each of the menu choices for later use in a switch-break.
        enum MenuChoices
        {
            NONE                = 0,
            ADD_EMPLOYEE        = 1,
            UPDATE_EMPLOYEE     = 2,
            PAY_EMPLOYEES       = 3,
            EXIT_PROGRAM        = 4
        }

        static void Main(string[] args)
        {
            MenuChoices nextCommand = MenuChoices.NONE;
            Employee[] employees = new Employee[50];
            int numberOfEmployees = 0;
            int employeeIndex = 0;

            // Use sentinel loop to begin menu prompts.
            while (nextCommand != MenuChoices.EXIT_PROGRAM)
            {
                string userSelection = "";
                userSelection = getMenuChoice();

                // Prompt the user for a command.
                nextCommand = getSelectionFromMenuChoice(userSelection);

                // Add employee if user selects option 1.
                if (nextCommand == MenuChoices.ADD_EMPLOYEE)
                {
                    Employee newEmployee = getEmployeeInformation();
                    
                    Console.WriteLine();

                    // Add the new employee to the employees array.
                    employees[employeeIndex] = newEmployee;
                    employeeIndex++;
                    numberOfEmployees++;

                    Console.WriteLine();
                }

                // Update employee information if user selects option 2.
                if (nextCommand == MenuChoices.UPDATE_EMPLOYEE)
                {
                    string userInput = "";
                    int indexOfEmployee = 0;

                    // Ask user which employee they wish to update.
                    Console.Write("There are currently {0} employess. \n" +
                        "Which employee do you want to update (0-{0})? ", (numberOfEmployees - 1));
                    userInput = Console.ReadLine();
                    indexOfEmployee = int.Parse(userInput);

                    // Replace old information with new information.
                    employees[indexOfEmployee] = getEmployeeInformation();
                }

                // Show payroll if user selects option 3.
                if (nextCommand == MenuChoices.PAY_EMPLOYEES)
                {
                    Console.WriteLine("Payroll: ");

                    for (int index = 0; index < numberOfEmployees; index++)
                    {
                        float pay = 0.0f;
                        float wage = employees[index].Wage;
                        float hours = employees[index].HoursWorked;

                        // Check that the employee is actually on the payroll.
                        if (employees[index].OnThePayroll == true)
                        {
                            pay = (wage * hours);
                            Console.Write("{0}: ${1}", employees[index].FirstName, pay);

                            Console.WriteLine();
                        }
                     }
                }
            }
        }

        // Display the menu for the user.
        static void DisplayMenu()
        {
            Console.WriteLine();

            Console.WriteLine("Please select an option below: \n" +
                "1. Add an employee. \n" +
                "2. Update existing employee information. \n" +
                "3. Pay employees.\n" + 
                "4. Exit program.");
        }

        // Get the user's choice. 
        private static string getMenuChoice()
        {
            string menuChoice = "";

            DisplayMenu();

            Console.Write("\nEnter number of choice --> ");
            menuChoice = Console.ReadLine();

            Console.WriteLine();

            return menuChoice;
        }

        // Check which selection the user made.
        private static MenuChoices getSelectionFromMenuChoice(string menuChoice)
        {
            MenuChoices selection = MenuChoices.NONE;

            switch(menuChoice[0])
            {
                case '1':
                    selection = MenuChoices.ADD_EMPLOYEE;
                    break;
                case '2':
                    selection = MenuChoices.UPDATE_EMPLOYEE;
                    break;
                case '3':
                    selection = MenuChoices.PAY_EMPLOYEES;
                    break;
                case '4':
                    selection = MenuChoices.EXIT_PROGRAM;
                    break;
                default:
                    throw new Exception("Error. Enter an integer (1-4)");
            }

            return selection;
        }

        // Method for getting all of the employee information.
        private static Employee getEmployeeInformation()
        {
            Employee anEmployee = new Employee();
            //int employeeIndex = 0;
            string wageTemp = "";
            string hourTemp = "";

            Console.Write("Enter the first name of employee: ");
            anEmployee.FirstName = Console.ReadLine();

            Console.Write("Enter the last name of employee: ");
            anEmployee.LastName = Console.ReadLine();

            Console.Write("Enter the phone number of the employee: ");
            anEmployee.PhoneNumber = Console.ReadLine();

            Console.Write("Enter the job title of employee: ");
            anEmployee.JobTitle = Console.ReadLine();

            Console.Write("Enter the wage of the employee: ");
            wageTemp = Console.ReadLine();
            anEmployee.Wage = float.Parse(wageTemp);

            Console.Write("Enter the hours worked for the employee: ");
            hourTemp = Console.ReadLine();
            anEmployee.HoursWorked = float.Parse(hourTemp);

            anEmployee.OnThePayroll = CheckIfEmployeeOnThePayroll();

            return anEmployee;
        }

        // Method for checking if the employee is on the payroll.
        private static bool CheckIfEmployeeOnThePayroll()
        {
            string payrollStatusTemp = "";
            bool onPayroll = false;

            Console.Write("Is this employee on the payroll (y/n)? ");
            payrollStatusTemp = Console.ReadLine();

            // Check if user entered y.
            if (payrollStatusTemp[0] == 'y')
            {
                onPayroll = true;
            }

            return onPayroll;
        }
    }
}
