using Menedzer_Kalorii.Commands;
using Menedzer_Kalorii.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Menedzer_Kalorii.ViewModel
{
    class AmountWindowViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        AmountWindowModel Model = new AmountWindowModel();
        public AmountWindowViewModel()
        {
            closeWindowCommand = new RelayCommand(closeWindow);
        }

        public ICommand closeWindowCommand { get; set; }

        private void closeWindow(object obj)
        {
            (obj as Window).Close();
        }


    }
}
