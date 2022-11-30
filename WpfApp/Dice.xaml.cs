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
        private float maxProgress;
        private float progress;
        private bool isIndeterminate;

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

        public float MaxProgress
        {
            get => maxProgress; set
            {
                maxProgress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MaxProgress)));
            }
        }
        public float Progress
        {
            get => progress; set
            {
                progress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progress)));
            }
        }
        public bool IsIndeterminate
        {
            get => isIndeterminate; set
            {
                isIndeterminate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsIndeterminate)));
            }
        }


        private async void Button_Roll_Click(object sender, RoutedEventArgs e)
        {
            await RollAsync();
        }

        public async Task RollAsync()
        {
            var random = new Random();
            MaxProgress = Dices.Count;
            Progress = 0;
            var tasks = Dices.Where(x => !x.IsLocked).Select(x => RollAsync(random, x)).ToArray();

            await Task.WhenAll(tasks);
        }

        private async Task RollAsync(Random random, Models.Dice dice)
        {
            var numberOfRols = random.Next(25, 75);
            for (int i = 0; i < numberOfRols; i++)
            {
                dice.Value = random.Next(1, 7);
                await Task.Delay(25);
            }

            Progress++;
        }
    }
}
