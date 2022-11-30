using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Models
{
    public class Product : INotifyPropertyChanged, ICloneable, IDataErrorInfo, INotifyDataErrorInfo
    {
        private string name = "";
        private DateTime expirationDate;
        private decimal price;


        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 5)
                {
                    _errorDictionary[nameof(Name)] = "Nazwa musi mieć conajmniej 5 znaków";
                }
                else
                {
                    _errorDictionary.Remove(nameof(Name));
                }
                name = value;
                OnPropertyChanged();
                OnErrorChanged();

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


        #region IDataErrorInfo
        private Dictionary<string, string> _errorDictionary { get; } = new Dictionary<string, string>();

        public string this[string columnName] => _errorDictionary.TryGetValue(columnName, out var error) ? error : string.Empty;
        public string Error => string.Join("\n", _errorDictionary.Select(x => x.Value));

        #endregion IDataErrorInfo


        #region IDataErrorInfo
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            return _errorDictionary.Select(x => x.Value);
        }
        public bool HasErrors => _errorDictionary.Any();

        public void OnErrorChanged([CallerMemberName] string nameOfProperty = "")
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameOfProperty));
        }
        #endregion IDataErrorInfo

    }
}