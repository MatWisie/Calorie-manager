﻿using Menedzer_Kalorii.Class;
using Menedzer_Kalorii.Commands;
using Menedzer_Kalorii.Model;
using Menedzer_Kalorii.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
            calculateFoodKcalCommand = new RelayCommand(calculateFoodKcal);
            planMealClickCommand = new RelayCommand(planMealClick);
            addFoodCommand = new RelayCommand(addFood);
            saveMealCommand = new RelayCommand(saveMeal);
            removeLastItemBreakfastCommand = new RelayCommand(removeLastItemBreakfast);
            removeLastItemLunchCommand = new RelayCommand(removeLastItemLunch);
            removeLastItemSupperCommand = new RelayCommand(removeLastItemSupper);
            calculateCaloriesBurnedCommand = new RelayCommand(calculateCaloriesBurned);

            kcalDefining kcalDefining = new kcalDefining();

            _breakfastBackground = Brushes.White;
            _lunchBackground = Brushes.White;
            _supperBackground = Brushes.White;

            date = DateTime.Now.Date;

            _kcal = 0;
            
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

        public string verdict
        {
            get { return Model._verdict; }
            set
            {
                Model._verdict = value;
                OnPropertyChanged();
            }
        }
        public ICommand calculateBmiCommand { get; set; }
        private void CalculateBmi(object obj)
        {
            BMI = Math.Round(weight/Math.Pow(height,2),2);
            if (BMI < 16)
            {
                verdict = "Wartość: WYGŁODZENIE \n Życie takiej osoby jest zagrożone, musisz zadbać o siebie, zacząć więcej jeść i przybrać wagi. W razie problemów polecamy udać się do specjalisty.";
            }
            if (BMI < 16.99 && BMI > 16)
            {
                verdict = "Wartość: WYCHUDZENIE \n Stan ten jest niezdrowy dla twojego ciała. Zalecamy przemyślenie swojej diety i nabrania wagi. W razie problemów polecamy udać się do specjalisty lub skorzystać z naszego kalkulatora kalorii";
            }
            if (BMI < 18.49 && BMI > 17)
            {
                verdict = "Wartość: NIEDOWAGA \n Twoja waga jest za niska, lecz nie jesteś tak daleko od wagi prawidłowej. Zalecamy nabrania wagi. Zalecamy przemyślenie swojej diety. W razie problemów polecamy skorzystać z naszego kalkulatora kalorii";
            }
            if (BMI < 24.99 && BMI > 25)
            {
                verdict = "Wartość: WAGA PRAWIDŁOWA \n Twoja waga jest prawidłowa, tak trzymaj. Utrzymaj ten stan poprzez zdrowe odżywianie i regularne ćwiczenia.";
            }
            if (BMI < 29.99 && BMI > 25)
            {
                verdict = "Wartość: NADWAGA \n Ważysz za dużo, przemyśl swoją dietę, ćwicz regularnie i zrzuć parę kilo aby wrócić do wagi prawidłowej.";
            }
            if (BMI < 39.99 && BMI > 30)
            {
                verdict = "Wartość: OTYŁOŚĆ \n Stan ten jest niezdrowy dla twojego ciała. Zalecamy przemyślenie swojej diety i stracenia wagi poprzez zdrowe odżywianie i regularne ćwiczenia. W razie problemów polecamy udać się do specjalisty lub skorzystać z naszego kalkulatora kalorii oraz planowania ćwiczeń";
            }
            if (BMI > 40)
            {
                verdict = "Wartość: OTYŁOŚĆ SKRAJNA \n Życie takiej osoby jest zagrożone, musisz zadbać o siebie, zacząć mniej jeść i starcić wagi, w przeciwnym razie stan ten może mieć przykre konsekwencje. W razie problemów polecamy udać się do specjalisty.";
            }
        }

        public ObservableCollection<string> _foodList
        {
            get
            {
                return Model.foodList;
            }
            set
            {
                Model.foodList = value;
            }
        }

        public double _kcal
        {
            get
            {
                return Math.Round(Model.kcal,2);
            }
            set
            {
                Model.kcal = value;
                OnPropertyChanged();
            }
        }
        public int _grams
        {
            get
            {
                return Model.grams;
            }
            set
            {
                Model.grams = value;
                OnPropertyChanged();
            }
        }
        public ICommand calculateFoodKcalCommand { get; set; }
        public void calculateFoodKcal(object obj)
        {
            AmountWindow amountwindow = new AmountWindow();
            amountwindow.ShowDialog();
            _grams = (int)amountwindow.gramsUpDown.Value;
            _foodList.Add((string)obj + " " + _grams + " gram");
            _kcal += kcalDefining.define((string)obj) * _grams;

        }



        public string _selectedcategory
        {
            get
            {
                return Model.selectedcategory;
            }
            set
            {
                Model.selectedcategory = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<string> _breakfastList
        {
            get
            {
                return Model.breakfastList;
            }
            set
            {
                Model.breakfastList = value;
            }
        }

        public ObservableCollection<string> _lunchList
        {
            get
            {
                return Model.lunchList;
            }
            set
            {
                Model.lunchList = value;
            }
        }

        public ObservableCollection<string> _supperList
        {
            get
            {
                return Model.supperList;
            }
            set
            {
                Model.supperList = value;
            }
        }


        

        public Brush _breakfastBackground
        {
            get { return Model.breakfastBackground; }
            set
            {
                Model.breakfastBackground = value;
                OnPropertyChanged();
            }
        }


        public Brush _lunchBackground
        {
            get { return Model.lunchBackground; }
            set
            {
                Model.lunchBackground = value;
                OnPropertyChanged();
            }
        }

        public Brush _supperBackground
        {
            get { return Model.supperBackground; }
            set
            {
                Model.supperBackground = value;
                OnPropertyChanged();
            }
        }


        public ICommand planMealClickCommand { get; set; }

        public void planMealClick(object obj)
        {
            _selectedcategory = obj.ToString();
            switch (_selectedcategory)
            {
                case "breakfast":
                    _breakfastBackground = Brushes.Gray;
                    _lunchBackground = Brushes.White;
                    _supperBackground = Brushes.White;
                    break;
                case "lunch":
                    _breakfastBackground = Brushes.White;
                    _lunchBackground = Brushes.Gray;
                    _supperBackground = Brushes.White;
                    break;
                case "supper":
                    _breakfastBackground = Brushes.White;
                    _lunchBackground = Brushes.White;
                    _supperBackground = Brushes.Gray;
                    break;
            }
        }


        ///here more ClickCommands

        public ICommand removeLastItemBreakfastCommand { get; set; }

        public void removeLastItemBreakfast(object obj)
        {
            if(_breakfastList.Count > 0)
            _breakfastList.RemoveAt(_breakfastList.Count-1);
        }

        public ICommand removeLastItemLunchCommand { get; set; }

        public void removeLastItemLunch(object obj)
        {
            if (_lunchList.Count > 0)
                _lunchList.RemoveAt(_lunchList.Count - 1);
        }


        public ICommand removeLastItemSupperCommand { get; set; }

        public void removeLastItemSupper(object obj)
        {
            if (_supperList.Count > 0)
                _supperList.RemoveAt(_supperList.Count - 1);
        }


        public ICommand addFoodCommand { get; set; }

        public void addFood(object obj)
        {
            switch (_selectedcategory)
            {
                case "breakfast":
                    _breakfastList.Add(obj.ToString());
                    break;
                case "lunch":
                    _lunchList.Add(obj.ToString());
                    break;
                case "supper":
                    _supperList.Add(obj.ToString());
                    break;

                default:
                    _breakfastList.Add(obj.ToString());
                    break;
            }

        }

        public string writeOut(ObservableCollection<string> foodList)
        {
            string result = "";
            foreach(string food in foodList)
            {
                result += food + "\n";
            }
            return result;
        }

        public ICommand saveMealCommand { get; set; }

        public void saveMeal(object obj)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, "||||||||Menedżer Kalorii|||||||| \n\n|Śniadanie| \n" + writeOut(_breakfastList) + "\n|Obiad|\n" + writeOut(_lunchList) + "\n|Kolacja|\n" + writeOut(_supperList));
            }

        }


        public int _minutes
        {
            get { return Model.minutes; }
            set
            {
                Model.minutes = value;
                OnPropertyChanged();
            }
        }

        public double _burnedCalories
        {
            get { return Model.burnedCalories; }
            set
            {
                Model.burnedCalories = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<string> _exercisesList
        {
            get
            {
                return Model.exercisesList;
            }
            set
            {
                Model.exercisesList = value;
            }
        }

        public ICommand calculateCaloriesBurnedCommand { get; set; }
        public void calculateCaloriesBurned(object obj)
        {
            MinutesWindow minuteswindow = new MinutesWindow();
            minuteswindow.ShowDialog();
            _minutes = (int)minuteswindow.gramsUpDown.Value;
            _exercisesList.Add((string)obj + " " + _minutes + " minut");
            _burnedCalories += burnedKcalDefining.define((string)obj) * _minutes;
        }


    }
}
