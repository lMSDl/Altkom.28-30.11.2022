using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Dice.xaml
    /// </summary>
    public partial class Dice : Window, INotifyPropertyChanged
    {
        private int numberOfDice;

        public Dice()
        {
            InitializeComponent();
            DataContext = this;
            Dices = new ObservableCollection<Models.Dice>();
            NumberOfDice = 6;

            //Dices.CollectionChanged += Dices_CollectionChanged;
        }

        /*private void Dices_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    NumberOfDice++;
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    NumberOfDice--;
                    break;
            }
        }*/

        public int NumberOfDice
        {
            get => numberOfDice;
            set
            {
                numberOfDice = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumberOfDice)));
                Button_Clear_Click(null, null);
            }
        }
        public ObservableCollection<Models.Dice> Dices { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

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
            Dices.Clear();
            for (int i = 0; i < NumberOfDice; i++)
            {
                Dices.Add(new Models.Dice());
            }
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            NumberOfDice++;
        }
        private void Button_Remove_Click(object sender, RoutedEventArgs e)
        {
            NumberOfDice--;
        }

        private void Dice_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is Models.Dice dice)
                {
                    dice.IsLocked = !dice.IsLocked;
                }
            }
        }
    }
}
