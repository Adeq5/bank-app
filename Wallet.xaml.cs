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
using bank.Data;
using bank.models;


namespace bank
{

    public partial class Wallet : Page
    {
        private User _currentUser;


        public Wallet(User user)
        {
            InitializeComponent();
            _currentUser = user;
            LoadUserData();
        }


        private void LoadUserData()
        {
   
            FirstNameTextBox.Text = _currentUser.FirstName;
            LastNameTextBox.Text = _currentUser.LastName;
            BalanceTextBox.Text = $"{_currentUser.Balance:F2}"; 
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainBank(_currentUser));  
        }


        private void NavigateToAccInfo(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EditAcc(_currentUser));  
        }

        private void AddMoney_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new BankContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Login == _currentUser.Login);

                if (user != null)
                {
                  
                    user.Balance += 100;
                    context.SaveChanges(); 


                    
                    _currentUser = user;  
                    LoadUserData(); 

                    MessageBox.Show("Added 100$.");
                }
            }
        }
    }
}
