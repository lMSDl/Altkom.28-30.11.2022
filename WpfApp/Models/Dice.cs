using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class Dice : INotifyPropertyChanged
    {
        private int value;
        private bool isLocked;

        public int Value
        {
            get => value;
            set
            {
                /*if (IsLocked)
                    return;*/

                this.value = value;

                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                OnPropertyChanged();
            }
        }
        public bool IsLocked
        {
            get => isLocked; 
            set
            {
                isLocked = value;
                OnPropertyChanged(nameof(IsLocked));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string nameOfProperty = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameOfProperty));
        }
    }
}
