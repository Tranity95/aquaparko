using System;
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

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                Signal();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void GoSignIn(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void Check_Register(object sender, RoutedEventArgs e)
        {
            string password = NewPassword.Password;
            string confirmPassword = NewPasswordConfirm.Password;
            if (password != confirmPassword || NewLogin == null || password == null || confirmPassword == null)
            {
                ErrorMessage = "Пароли не совпадают!";
                return;
            }
            else
            {
                MessageBox.Show("Регистрация прошла успешно!");
                DataBase.GetInstance().Users.Add(new User { RoleId = 2, FirstName = NewName, LastName=NewLastName, SurName = NewSurName, Login = NewLogin, Password = password });
                DataBase.GetInstance().SaveChanges();
            }
            
        }

        private void SignUp(object sender, RoutedEventArgs e)
        {
            Check_Register(sender, e);
        }
    }
}
