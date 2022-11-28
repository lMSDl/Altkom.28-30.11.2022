﻿using Models;
using Models.Fakers;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ItemsControlWindow.xaml
    /// </summary>
    public partial class ItemsControlWindow : Window
    {
        public ItemsControlWindow()
        {
            InitializeComponent();
            DataContext = this;

            Products = new ProductFaker().Generate(15);
        }

        public IEnumerable<Product> Products { get; set; }
    }
}
