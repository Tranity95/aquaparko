using Microsoft.EntityFrameworkCore;
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

namespace aquaparko
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User user { get; }
        public string Login { get; set; }
        public PasswordBox Password { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Password = Passwordo;
        }

        private void SignIn(object sender, RoutedEventArgs e)
        {
            using (AquaparkoContext context = new AquaparkoContext())
            {
                var user = context.Users.Include(s => s.Role).FirstOrDefault(a => a.Login == Login && a.Password == Password);
                if (user != null)
                {
                    new Navigation(user).Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неправильный Логин или пароль");
                }
            }
        }

        private void GoSignUp(object sender, RoutedEventArgs e)
        {
            new Register().Show();
            Close();
        }

        private void IForgor(object sender, RoutedEventArgs e)
        {
            new Forgot().Show();
            Close();
        }
    }
}