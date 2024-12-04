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
using System.Windows.Shapes;
using System.Security.Cryptography;
using bank.Data;
using bank.models;

namespace bank
{
    public partial class CreateAcc : Page
    {
        public CreateAcc()
        {
            InitializeComponent();
            using (var context = new BankContext())
            {
                context.Database.EnsureCreated(); 
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = (MainWindow)Window.GetWindow(this);
            MainWindow.MainFrame.Content = null;
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("All inputs have to be filled.");
                return;
            }

            using (var context = new BankContext())
            {

                if (context.Users.Any(u => u.Login == login))
                {
                    MessageBox.Show("User with this login already exists.");
                    return;
                }

  
                var user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Login = login,
                    PasswordHash = HashPassword(password), 
                    Balance = 0 
                };


                context.Users.Add(user);
                context.SaveChanges(); 

                MessageBox.Show("Register success!");

                var MainWindow = (MainWindow)Window.GetWindow(this);
                MainWindow.MainFrame.Content = null;
            }

        }
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}