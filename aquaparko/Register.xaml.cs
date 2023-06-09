﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace aquaparko
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window, INotifyPropertyChanged
    {
        private string errorMessage;

        void Signal([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public string NewLogin { get; set; }
        public PasswordBox NewPassword { get; set; }
        public PasswordBox NewPasswordConfirm { get; set; }
        public string NewName { get; set; }
        public string NewLastName { get; set; }
        public string NewSurName { get; set; }


        public Register()
        {
            InitializeComponent();
            this.DataContext = this;
            NewPassword = txtNewPassword;
            NewPasswordConfirm = txtNewPasswordConfirm;
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void GoSignIn(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void Check_Register(object sender, RoutedEventArgs e)
        {
            

            if (NewPassword.SecurePassword.Length > 15)
            {
                MessageBox.Show("Пароль не может быть длиннее 15 символов!");
                return;
            }
            string password = NewPassword.Password;
            string confirmPassword = NewPasswordConfirm.Password;
            if (NewLogin == null || password == null || confirmPassword == null || NewName == null || NewLastName == null || NewSurName == null)
            {
                MessageBox.Show("Вы ввели не все данные");
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }
            else
            {
                MessageBox.Show("Регистрация прошла успешно!");
                DataBase.Instance.Users.Add(new User { RoleId = 2, FirstName = NewName, LastName=NewLastName, SurName = NewSurName, Login = NewLogin, Password = password });
                DataBase.Instance.SaveChanges();
            }
            
        }

        private void SignUp(object sender, RoutedEventArgs e)
        {
            Check_Register(sender, e);
        }
    }
}
