using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_GUI
{
    public partial class FormPayroll : Form
    {
        public FormPayroll()
        {
            InitializeComponent();
        }

        Employee[] employees = new Employee[50];
        int numberOfEmployees = 0;

        private void ButtonAddEmployee_Click(object sender, EventArgs e)
        {
            ButtonUpdateEmployee.Enabled = false;

            // Create a new employee.
            Employee newEmployee = new Employee();

            if (AllDataIsValid())
            {
                // Fill out the new employee's information
                newEmployee.personAddress.StreetAddress     = TextBoxStreetAddress.Text;
                newEmployee.personAddress.ApartmentNumber   = TextBoxApartmentNumber.Text;
                newEmployee.personAddress.City              = TextBoxCity.Text;
                newEmployee.personAddress.State             = TextBoxState.Text;
                newEmployee.personAddress.Zip               = TextBoxZip.Text;

                newEmployee.FirstName                       = TextBoxFirstName.Text;
                newEmployee.LastName                        = TextBoxLastName.Text;
                newEmployee.PhoneNumber                     = TextBoxPhoneNumber.Text;

                newEmployee.JobTitle                        = TextBoxJobTitle.Text;
                newEmployee.Wage                            = float.Parse(TextBoxWage.Text);
                newEmployee.HoursWorked                     = float.Parse(TextBoxHoursWorked.Text);
                newEmployee.OnThePayroll                    = CheckBoxOnPayroll.Checked;

                // Add new employee to the array (listbox)
                employees[numberOfEmployees] = newEmployee;
                numberOfEmployees++;

                // Update the listbox
                UpdateEmployeesListbox();
            }
        }

        private void ButtonUpdateEmployee_Click(object sender, EventArgs e)
        {
            Employee selectedEmployee = employees[ListBoxEmployees.SelectedIndex];

            // Fill out the information with selected employee's info
            selectedEmployee.personAddress.StreetAddress    = TextBoxStreetAddress.Text;
            selectedEmployee.personAddress.ApartmentNumber  = TextBoxApartmentNumber.Text;
            selectedEmployee.personAddress.City             = TextBoxCity.Text;
            selectedEmployee.personAddress.State            = TextBoxState.Text;
            selectedEmployee.personAddress.Zip              = TextBoxZip.Text;

            selectedEmployee.FirstName                      = TextBoxFirstName.Text;
            selectedEmployee.LastName                       = TextBoxLastName.Text;
            selectedEmployee.PhoneNumber                    = TextBoxPhoneNumber.Text;

            selectedEmployee.JobTitle                       = TextBoxJobTitle.Text;
            selectedEmployee.Wage                           = float.Parse(TextBoxWage.Text);
            selectedEmployee.HoursWorked                    = float.Parse(TextBoxHoursWorked.Text);
            selectedEmployee.OnThePayroll                   = CheckBoxOnPayroll.Checked;

            UpdateEmployeesListbox();
        }

        private void UpdateEmployeesListbox()
        {
            ListBoxEmployees.Items.Clear();

            for (int i = 0; i < numberOfEmployees; i++)
            {
                ListBoxEmployees.Items.Add(employees[i]);
            }
        }

        private void ListBoxEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = ListBoxEmployees.SelectedIndex;
            if (i != -1)
            {
                ButtonUpdateEmployee.Enabled = true;

                // Display selected employee's information.
                TextBoxStreetAddress.Text               = employees[i].personAddress.StreetAddress;
                TextBoxApartmentNumber.Text             = employees[i].personAddress.ApartmentNumber;
                TextBoxCity.Text                        = employees[i].personAddress.City;
                TextBoxState.Text                       = employees[i].personAddress.State;
                TextBoxZip.Text                         = employees[i].personAddress.Zip;

                TextBoxFirstName.Text                   = employees[i].FirstName;
                TextBoxLastName.Text                    = employees[i].LastName;
                TextBoxPhoneNumber.Text                 = employees[i].PhoneNumber;

                TextBoxJobTitle.Text                    = employees[i].JobTitle;
                TextBoxWage.Text                        = employees[i].Wage.ToString();
                TextBoxHoursWorked.Text                 = employees[i].HoursWorked.ToString();
                CheckBoxOnPayroll.Checked               = employees[i].OnThePayroll;
            }
        }

        private void ButtonPayEmployees_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < numberOfEmployees; index++)
            {
                float pay       = 0.0f;
                float wage      = employees[index].Wage;
                float hours     = employees[index].HoursWorked;

                // Check that the employee is actually on the payroll.
                if (employees[index].OnThePayroll == true)
                {
                    pay = (wage * hours);
                    string paidEmployee = employees[index].FirstName + " " + employees[index].LastName;
                    MessageBox.Show("You paid: " + paidEmployee + " $" + pay + "!");
                }
            }
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool IsValidWage(string theWage)
        {
            float wage;

            if (float.TryParse(theWage, out wage))
                if (wage >= 0)
                    return true;

            return false;
        }

        private bool IsValidHoursWorked(string theHoursWorked)
        {
            float hoursWorked;

            if (float.TryParse(theHoursWorked, out hoursWorked))
                if (hoursWorked >= 0)
                    return true;

            return false;
        }

        private bool AllDataIsValid()
        {
            if (IsValidWage(TextBoxWage.Text) && IsValidHoursWorked(TextBoxHoursWorked.Text))
                return true;
            else
            {
                MessageBox.Show("The hours worked and wage must be non-negative numbers.");
                return false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LabelPayroll_Click(object sender, EventArgs e)
        {

        }

        private void TextBoxStreetAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
