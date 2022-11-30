using FluentValidation;
using FluentValidation.Results;
using Models.Validators;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Models
{
    public class Product : INotifyPropertyChanged, ICloneable, /*IDataErrorInfo,*/ INotifyDataErrorInfo
    {
        private string name = "";
        private DateTime expirationDate;
        private decimal price;
        private readonly ProductValidator _validator = new ProductValidator();
        private ValidationResult _validationResult;

        public string Name
        {
            get => name;
            set
            {
                //if (value.Length < 5)
                //{
                //    _errorDictionary[nameof(Name)] = "Nazwa musi mieć conajmniej 5 znaków";
                //}
                //else
                //{
                //    _errorDictionary.Remove(nameof(Name));
                //}
                name = value;
                OnPropertyChanged();
                //OnErrorChanged();

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
            OnErrorChanged();
        }


        //#region IDataErrorInfo
        //private Dictionary<string, string> _errorDictionary { get; } = new Dictionary<string, string>();

        //public string this[string columnName] => _errorDictionary.TryGetValue(columnName, out var error) ? error : string.Empty;
        //public string Error => string.Join("\n", _errorDictionary.Select(x => x.Value));

        //#endregion IDataErrorInfo


        #region INotifyDataErrorInfo
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            return _validationResult.Errors.Where(x => x.PropertyName == propertyName).Select(x => x.ErrorMessage).ToList();
            //return _errorDictionary.Select(x => x.Value);
        }
        public bool HasErrors => !_validationResult?.IsValid ?? false; //_errorDictionary.Any();

        public void OnErrorChanged([CallerMemberName] string nameOfProperty = "")
        {
            _validationResult = _validator.Validate(this);
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameOfProperty));
        }
        #endregion INotifyDataErrorInfo

    }
}