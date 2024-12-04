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
    /// <summary>
    /// Logika interakcji dla klasy EditAcc.xaml
    /// </summary>
    public partial class EditAcc : Page
    {
        private User _currentUser;

        public EditAcc(User user)
        {
            InitializeComponent();
            _currentUser = user;

            LoadUserData();
        }


        private void LoadUserData()
        {
            NameDisplay.Text = _currentUser.FirstName + " " + _currentUser.LastName;
            LoginDisplay.Text = _currentUser.Login;
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainBank(_currentUser));  
        }

        // Akcja przycisku edycji imienia
        private void EditName_Click(object sender, RoutedEventArgs e)
        {
            EditPanel.Visibility = Visibility.Visible;
            EditNameBox.Visibility = Visibility.Visible; 
            EditLoginBox.Visibility = Visibility.Collapsed; 
            EditNameBox.Text = _currentUser.FirstName + " " + _currentUser.LastName; 
        }

        // Akcja przycisku edycji loginu
        private void EditLogin_Click(object sender, RoutedEventArgs e)
        {
            EditPanel.Visibility = Visibility.Visible;
            EditLoginBox.Visibility = Visibility.Visible; 
            EditNameBox.Visibility = Visibility.Collapsed; 
            EditLoginBox.Text = _currentUser.Login; 
        }

        // Zapisz zmiany w danych użytkownika
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string newName = EditNameBox.Text;
            string newLogin = EditLoginBox.Text;


            using (var context = new BankContext())
            {
                var existingUser = context.Users.FirstOrDefault(u => u.Login == newLogin && u.Id != _currentUser.Id);
                if (existingUser != null)
                {
                    MessageBox.Show("User with this login exists. Choose another login.");
                    return;
                }


                if (EditNameBox.Visibility == Visibility.Visible)
                {
                    var names = newName.Split(' ');
                    _currentUser.FirstName = names[0];
                    _currentUser.LastName = names.Length > 1 ? names[1] : string.Empty;
                }

                if (EditLoginBox.Visibility == Visibility.Visible)
                {
                    _currentUser.Login = newLogin;
                }

                context.Users.Update(_currentUser);
                context.SaveChanges();


                LoadUserData();

                EditPanel.Visibility = Visibility.Collapsed;
                EditNameBox.Visibility = Visibility.Collapsed;
                EditLoginBox.Visibility = Visibility.Collapsed;

                MessageBox.Show("Data updated.");
            }
        }
    }
}

