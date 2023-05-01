using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Логика взаимодействия для RedakSlide.xaml
    /// </summary>
    public partial class RedakSlide : Window, INotifyPropertyChanged
    {
        public bool Editable { get; set; }

        public RedakSlide(Attraction selectedAttraction)
        {    
            InitializeComponent();
            DataContext = this;
            if (selectedAttraction.Id == 0 || selectedAttraction.Id == null)
            {
                SelectedAttraction = selectedAttraction;
                Editable = true;
            }
            else
                SelectedAttraction = selectedAttraction.CloneSlide();
        }

        public Attraction SelectedAttraction { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private void SaveClose(object sender, RoutedEventArgs e)
        {
            if (SelectedAttraction.Id == 0)
                DataBase.Instance.Attractions.Add(SelectedAttraction);
            else
            {
                var origin = DataBase.Instance.Attractions.Find(SelectedAttraction.Id);
                DataBase.Instance.Entry(origin).CurrentValues.SetValues(SelectedAttraction);
            }
            DataBase.Instance.SaveChanges();
            Close();
        }

        private void SelectPhoto(object sender, RoutedEventArgs e)
        {
            string dir = Environment.CurrentDirectory + @"\Images\";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images|*.png";
            if (dlg.ShowDialog() == true)
            {
                var test = new BitmapImage(new Uri(dlg.FileName));
                if (test.PixelWidth > 400 || test.PixelWidth > 300)
                {
                    MessageBox.Show("Картинка слшком большая");
                    return;
                }
                string newFile = dir + new FileInfo(dlg.FileName).Name;
                File.Copy(dlg.FileName, newFile, true);
                SelectedAttraction.Image = File.ReadAllText(newFile);
                Signal("SelectedAttraction");
            }
        }
    }
    public static class AttractionExtension
    {
        public static Attraction CloneSlide(this Attraction attraction)
        {
            var values = DataBase.Instance.Attractions.Entry(attraction).CurrentValues.Clone();
            var clone = (Attraction)values.ToObject();
            return clone;
        }
    }
}
