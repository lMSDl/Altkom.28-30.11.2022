using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Dice.xaml
    /// </summary>
    public partial class Dice : Window
    {
        public Dice()
        {
            InitializeComponent();
            DataContext= this;
            NumberOfDice = 6;

            Dices = new ObservableCollection<Models.Dice>();
            for (int i = 0; i < NumberOfDice; i++)
            {
                Dices.Add(new Models.Dice());
            }
        }

        public int NumberOfDice { get; set; }
        public ObservableCollection<Models.Dice> Dices { get; set; }

        private void Button_Roll_Click(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            foreach (var dice in Dices)
            {
                dice.Value = random.Next(1, 7);
            }
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            foreach (var dice in Dices)
            {
                dice.Value = 0;
            }
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Dices.Add(new Models.Dice());
        }
        private void Button_Remove_Click(object sender, RoutedEventArgs e)
        {
            if(Dices.Any())
                Dices.Remove(Dices.Last());
        }
    }
}
