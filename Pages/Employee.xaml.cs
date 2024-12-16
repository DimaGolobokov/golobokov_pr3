using golobokov_pr3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace golobokov_pr3.Pages
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Page
    {
        public Employee(Auth user, string role)
        {
            InitializeComponent();

            var db = Helper.GetContext();

            var employee = db.Employees.Where(x => x.AuthID == user.AuthID).FirstOrDefault();

            if (employee != null)
            {
                string firstName = employee.FirstName;
                string lastName = employee.LastName;

                string greetingMessage = GenerateGreeting(firstName, lastName);

                GreetingTextBlock.Text = greetingMessage;
            }
        }

        private string GenerateGreeting(string firstName, string lastName)
        {
            string greeting = GetTimeOfDayGreeting();
            greeting += $", {lastName} {firstName}!";
            return greeting;
        }

        private string GetTimeOfDayGreeting()
        {
            int currentHour = DateTime.Now.Hour;

            if (currentHour >= 10 && currentHour < 12)
            {
                return "Доброе утро";
            }
            else if (currentHour >= 12 && currentHour < 17)
            {
                return "Добрый день";
            }
            else if (currentHour >= 17 && currentHour < 19)
            {
                return "Добрый вечер";
            }

            return "";
        }
    }
}
