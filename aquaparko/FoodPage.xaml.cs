using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aquaparko
{
    /// <summary>
    /// Логика взаимодействия для FoodPage.xaml
    /// </summary>
    public partial class FoodPage : Page, INotifyPropertyChanged
    {

        public FoodPage()
        {
            InitializeComponent();
            this.DataContext = this;

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        
        private void Search()
        {
            var result = DataBase.Instance.Products.Include(s => s.Foods);
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveProduct(object sender, RoutedEventArgs e)
        {

        }

        private void EditProduct(object sender, RoutedEventArgs e)
        {

        }
    }
}
