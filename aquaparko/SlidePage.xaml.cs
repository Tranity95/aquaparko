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
    /// Логика взаимодействия для SlidePage.xaml
    /// </summary>
    public partial class SlidePage : Page, INotifyPropertyChanged
    {
        public string FIO { get; }
        private readonly User user;
        public string CountView { get; set; }

        public List<Attraction> Attractions { get; set; }
        public Attraction SelectedAttraction { get; set; }
        public List<string> Sorting { get; set; } = new List<string>() { "Без сортировки", "Уровень страха по убыванию", "Уровень страха по возрастанию" };

        public Visibility IsAdminVisibility { get; set; } = Visibility.Visible;
        private int selectedSorting;
        private string searchText = "";

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

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
        private void Search()
        {
            var result = DataBase.Instance.Attractions.Where(s=> s.Title.Contains(searchText));
            if (selectedSorting == 1)

                result = result.OrderByDescending(s => s.ScaryLvl);
            if (selectedSorting == 2)
                result = result.OrderBy(s => s.ScaryLvl);
            Attractions = result.ToList();
            Signal(nameof(Attractions));

            CountView = $"Записей: {Attractions.Count} из {DataBase.Instance.Attractions.Count()}";
            Signal(nameof(CountView));
            

        }

        public SlidePage(User user)
        {
            this.user = user;
            InitializeComponent();
            DataContext = this;
            Search();
            FIO = $"{user.FirstName} {user.LastName} {user.SurName}";

            IsAdminVisibility =
                user.RoleId == 1 ?
                Visibility.Visible :
                Visibility.Collapsed;
        }

        private void AddSlide(object sender, RoutedEventArgs e)
        {
            new RedakSlide(new Attraction()).ShowDialog();
            Search();
        }

        private void RemoveSlide(object sender, RoutedEventArgs e)
        {
            if (SelectedAttraction != null)
            {
                if (MessageBox.Show("Удалить выбранный аттракцион из списка?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DataBase.Instance.Attractions.Remove(SelectedAttraction);
                    DataBase.Instance.SaveChanges();
                    Search();
                }
            }
        }

        private void EditSlide(object sender, MouseButtonEventArgs e)
        {
            if (user.RoleId != 1)
            {
                return;
            }
            if (SelectedAttraction != null)
            {
                new RedakSlide(SelectedAttraction).ShowDialog();
                Search();
            }
        }

        private void EditSlide(object sender, RoutedEventArgs e)
        {
            if (SelectedAttraction != null)
            {
                new RedakSlide(SelectedAttraction).ShowDialog();
                Search();
            }
        }
    }
}
