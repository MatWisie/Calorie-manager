using Menedzer_Kalorii.Commands;
using Menedzer_Kalorii.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Menedzer_Kalorii.ViewModel
{
    class MinutesWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        MinutesWindowModel Model = new MinutesWindowModel();
        public MinutesWindowViewModel()
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
