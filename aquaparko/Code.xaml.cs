﻿using System;
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
    /// Логика взаимодействия для Code.xaml
    /// </summary>
    public partial class Code : Window
    {
        public string Codo { get; set; }
        public Code(string codo)
        {
            InitializeComponent();
            DataContext = this;
            Codo = codo;
        }
    }
}
