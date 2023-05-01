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
        public string FIO { get; }
        private readonly User user;
        public string CountView { get; set; }
        private string searchText = "";
        private int selectedSorting;
        private Type selecetedType = new Type { Id = 0 };

        public List<Type> Types { get; set; }
        public List<Food> Foods { get; set; }
        public Food SelectedFood { get; set; }
        public List<string> Sorting { get; set; } = new List<string>() { "Без сортировки", "Стоимость по убыванию", "Стоимость по возрастанию" };

        public Visibility IsAdminVisibility = Visibility.Visible;

        public Type SelectedType 
        { 
            get => selecetedType;
            set
            { 
                selecetedType = value;
                Search();
            } 
        }


        public int SelectedSorting
        {
            get => selectedSorting;
            set
            {
                selectedSorting = value;
                Search();
            }
        }

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                Search();
            }
        }

        Type allTypes = new Type { Id = 0, Title = "Все" };

        public FoodPage(User user)
        {
            InitializeComponent();
            this.user = user;
            DataContext = this;
            Types = DataBase.Instance.Types.ToList();
            Types.Add(allTypes);
            selecetedType = allTypes;
            Signal(nameof(Types));
            Search();
            FIO = $"{user.FirstName} {user.LastName} {user.SurName}";

            IsAdminVisibility =
            user.RoleId == 1 ?
            Visibility.Visible :
            Visibility.Collapsed;

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private void Search()
        {
            var result = DataBase.Instance.Foods.Include(s => s.Products).Where(s => s.Title.Contains(searchText));
            if (SelectedType != null && SelectedType.Id != allTypes.Id) 
                result = result.Where(s => s.Type == SelectedType.Id);
            if (selectedSorting == 1)
                result = result.OrderByDescending(s => s.Price);
            else if (selectedSorting == 2)
                result = result.OrderBy(s => s.Price);
            Foods = result.ToList();
            Signal(nameof(Foods));

            CountView = $"Записей: {Foods.Count} из {DataBase.Instance.Foods.Count()}";
            Signal(nameof(CountView));
        }

        private void AddFood(object sender, RoutedEventArgs e)
        {
            new RedakFood(new Food()).ShowDialog();
            Search();
        }

        private void EditFood(object sender, RoutedEventArgs e)
        {
            if (SelectedFood != null)
            {
                new RedakFood(SelectedFood).ShowDialog();
                Search();
            }
        }

        private void RemoveFood(object sender, RoutedEventArgs e)
        {
            if (SelectedFood != null)
            {
                if (MessageBox.Show("Удалить выбранное блюдо из списка?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DataBase.Instance.Foods.Remove(SelectedFood);
                    DataBase.Instance.SaveChanges();
                    Search();
                }
            }
        }
        private void EditFood(object sender, MouseButtonEventArgs e)
        {
            if (user.RoleId != 1)
            {
                return;
            }
            if (SelectedFood != null)
            {
                new RedakFood(SelectedFood).ShowDialog();
                Search();
            }
        }
    }
}
