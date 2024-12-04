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

namespace bank
{
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = (MainWindow)Window.GetWindow(this);
            MainWindow.MainFrame.Content = null;
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter data.");
                return;
            }

            using (var context = new BankContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Login == login);
                if (user != null && VerifyPassword(password, user.PasswordHash))
                {
                    MessageBox.Show("Log in successful!");

                    MainBank mainBankPage = new MainBank(user);
                    NavigationService.Navigate(mainBankPage);  
                }
                else
                {
                    MessageBox.Show("Incorrect login or pass.");
                }
            }
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                string hashString = Convert.ToBase64String(hashBytes);
                return hashString == storedHash;
            }
        }
    }
}



