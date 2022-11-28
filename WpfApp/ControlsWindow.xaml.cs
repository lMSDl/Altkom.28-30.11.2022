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
    /// Interaction logic for ControlsWindow.xaml
    /// </summary>
    public partial class ControlsWindow : Window
    {
        public ControlsWindow()
        {
            InitializeComponent();

            MyTextBlock.Inlines.Add(new Run("bold") { FontWeight = FontWeights.Bold });

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("BYE!");
            var element = ((FrameworkElement)sender);
            element.Visibility = Visibility.Hidden;

            Task.Delay(5000).ContinueWith(t => Dispatcher.Invoke(() => element.Visibility = Visibility.Visible));
        }

        private void CheckBox_Main_Click(object sender, RoutedEventArgs e)
        {
            CheckBoxChild1.IsChecked = CheckBoxChild2.IsChecked = CheckBoxChild3.IsChecked = CheckBoxMain.IsChecked ?? false;
        }

        private void CheckBoxChild_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxChild1.IsChecked == true && CheckBoxChild2.IsChecked == true && CheckBoxChild3.IsChecked == true)
                CheckBoxMain.IsChecked = true;
            else if (CheckBoxChild1.IsChecked == false && CheckBoxChild2.IsChecked == false && CheckBoxChild3.IsChecked == false)
                CheckBoxMain.IsChecked = false;
            else
                CheckBoxMain.IsChecked = null;
        }
    }
}
