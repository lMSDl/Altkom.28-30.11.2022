using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp_MVVM.Commands
{
    public class ShowDetailsCommand : ICommand
    {
        private Product? product;

        public event EventHandler? CanExecuteChanged;

        public Product? Product
        {
            get => product;
            set
            {
                product = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object? parameter)
        {
            return Product != null;
        }

        public void Execute(object? parameter)
        {
            MessageBox.Show($"Data przydatności: {Product!.ExpirationDate}");
        }
    }
}
