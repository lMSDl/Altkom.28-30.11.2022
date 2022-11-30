using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Models
{
    public class Product : INotifyPropertyChanged, ICloneable
    {
        private string name = "";
        private DateTime expirationDate;
        private decimal price;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();

            }
        }
        public DateTime ExpirationDate
        {
            get => expirationDate;
            set
            {
                expirationDate = value;
                OnPropertyChanged();
            }
        }
        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }

        public void OnPropertyChanged([CallerMemberName] string nameOfProperty = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameOfProperty));
        }
    }
}