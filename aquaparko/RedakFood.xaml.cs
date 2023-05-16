using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для RedakFood.xaml
    /// </summary>
    public partial class RedakFood : Window, INotifyPropertyChanged
    {
        public bool Editable { get; set; }
        public List<Type> Types { get; set; }
        public RedakFood(Food selectedFood)
        {
            InitializeComponent();
            Types = DataBase.Instance.Types.ToList();
            DataContext = this;
            if (selectedFood.Id == 0 || selectedFood.Id == null)
            {
                SelectedFood = selectedFood;
                Editable = true;
            }
            else
                SelectedFood = selectedFood.CloneFood();
        }
        public Food SelectedFood { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private void SaveClose(object sender, RoutedEventArgs e)
        {
                if (SelectedFood.Id == 0)
                    DataBase.Instance.Foods.Add(SelectedFood);
                else
                {
                    SelectedFood.Type = SelectedFood.TypeNavigation?.Id;
                    var origin = DataBase.Instance.Foods.Find(SelectedFood.Id);
                    DataBase.Instance.Entry(origin).CurrentValues.SetValues(SelectedFood);
                }
                DataBase.Instance.SaveChanges();
                Close();
        }

        private void SelectPhoto(object sender, RoutedEventArgs e)
        {
            string dir = Environment.CurrentDirectory + @"\images\";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images|*.png;*.jpg;*.jpeg";
            if(dlg.ShowDialog() == true)
            {
                var test = new BitmapImage(new Uri(dlg.FileName));
                if(test.PixelWidth > 400 || test.PixelWidth > 300)
                {
                    MessageBox.Show("Картинка слишком большая");
                    return;
                }
                string newFile = dir + new FileInfo(dlg.FileName).Name;
                File.Copy(dlg.FileName, newFile, true);
                SelectedFood.Image = @"\images\" + new FileInfo(dlg.FileName).Name;
                Signal("SelectedFood");
            }
        }

    }

    public static class FoodExtension
    {
        public static Food CloneFood(this Food food)
        {
            var values = DataBase.Instance.Foods.Entry(food).CurrentValues.Clone();
            var clone = (Food)values.ToObject();
            clone.Type = food.Type;
            return clone;
        }
    }
}
