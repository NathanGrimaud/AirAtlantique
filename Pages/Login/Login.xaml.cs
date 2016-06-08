using System;
using System.Windows;
using System.Windows.Controls;
using AirAtlantique.Model;
using AirAtlantique.DAO;
using AirAtlantique.Services;
using System.DirectoryServices;
using System.Collections;
using System.Text;

namespace AirAtlantique.Pages.Login
{

    public partial class Login 
    {
        private Employe admin { get; set; }
        public Login() : base()
        {
            InitializeComponent();
            changePage.Click += ChangePage_Click;
            
        }

        private void ChangePage_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameBox.Text;
            var passwd = PasswordBox.Password;
            var emp = connect(username, passwd);
            Switcher.Navigate(new Home.Home(emp));
        }
        public Employe connect(string username, string pass)
        {
            var emp = EmployéDAO.SelectUniqueEmployé(username);
            emp.password = pass;
            Switcher.loadProfile(emp);
            return emp;
        }   
    }
}
