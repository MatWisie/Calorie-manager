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
    class MainWindowViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        MainWindowModel Model = new MainWindowModel();

        public MainWindowViewModel()
        {
            calculateBmiCommand = new RelayCommand(CalculateBmi);

            date = DateTime.Now.Date;
        }



        public DateTime date
        {
            get { return Model._date; }
            set
            {
                Model._date = value;
                OnPropertyChanged();
            }
        }

        public double weight
        {
            get { return Model._weight; }
            set
            {
                Model._weight = value;
                OnPropertyChanged();
            }
        }

        public double height
        {
            get { return Model._height; }
            set
            {
                Model._height = value;
                OnPropertyChanged();
            }
        }
        public double BMI
        {
            get { return (double)Model._bmi; }
            set
            {
                Model._bmi = value;
                OnPropertyChanged();
            }
        }

        public ICommand calculateBmiCommand { get; set; }
        private void CalculateBmi(object obj)
        {
            BMI = height / weight;
        }
    }
}
