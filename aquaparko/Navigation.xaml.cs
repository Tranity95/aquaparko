using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для Navigation.xaml
    /// </summary>
    public partial class Navigation : Window, INotifyPropertyChanged
    {
        private User user;
        private Page currentPage;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Page CurrentPage 
        { 
            get => currentPage;
            set 
            { 
                currentPage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPage)));
            }
        }
        public Navigation(User user)
        {
            InitializeComponent();
            this.DataContext = this;
            CurrentPage = new MainPage(user);
            this.user = user;

        }

        private void GoFood(object sender, RoutedEventArgs e)
        {
            CurrentPage = new FoodPage();
        }

        private void GoSpa(object sender, RoutedEventArgs e)
        {
            CurrentPage = new SpaPage();
        }

        private void GoSlide(object sender, RoutedEventArgs e)
        {
            CurrentPage = new SlidePage();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void GoMain(object sender, RoutedEventArgs e)
        {
            CurrentPage = new MainPage(user);
        }
    }
}
