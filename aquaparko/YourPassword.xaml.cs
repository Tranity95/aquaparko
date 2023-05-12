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

namespace aquaparko
{
    /// <summary>
    /// Логика взаимодействия для YourPassword.xaml
    /// </summary>
    public partial class YourPassword : Window
    {
        public string Password { get; set; }

        public YourPassword(User user)
        {
            InitializeComponent();
            DataContext = this;
            Password = user.Password;
        }

        private void BackTo(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
