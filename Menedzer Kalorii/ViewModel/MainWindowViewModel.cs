using Menedzer_Kalorii.Class;
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
            exerciseChangeColorCommand = new RelayCommand(exerciseChangeColor);
            addExerciseCommand = new RelayCommand(addExercise);
            saveExerciseCommand = new RelayCommand(saveExercise);
            removeLastExerciseCommand = new RelayCommand(removeLastExercise);

            kcalDefining kcalDefining = new kcalDefining();

            _breakfastBackground = Brushes.White;
            _lunchBackground = Brushes.White;
            _supperBackground = Brushes.White;

            _mondayBackground = Brushes.White;
            _tuesdayBackground = Brushes.White;
            _wednesdayBackground = Brushes.White;
            _thursdayBackground = Brushes.White;
            _fridayBackground = Brushes.White;
            _saturdayBackground = Brushes.White;
            _sundayBackground = Brushes.White;

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


        public Brush _mondayBackground
        {
            get { return Model.mondayBackground; }
            set
            {
                Model.mondayBackground = value;
                OnPropertyChanged();
            }
        }
        public Brush _tuesdayBackground
        {
            get { return Model.tuesdayBackground; }
            set
            {
                Model.tuesdayBackground = value;
                OnPropertyChanged();
            }
        }

        public Brush _wednesdayBackground
        {
            get { return Model.wednesdayBackground; }
            set
            {
                Model.wednesdayBackground = value;
                OnPropertyChanged();
            }
        }

        public Brush _thursdayBackground
        {
            get { return Model.thursdayBackground; }
            set
            {
                Model.thursdayBackground = value;
                OnPropertyChanged();
            }
        }

        public Brush _fridayBackground
        {
            get { return Model.fridayBackground; }
            set
            {
                Model.fridayBackground = value;
                OnPropertyChanged();
            }
        }

        public Brush _saturdayBackground
        {
            get { return Model.saturdayBackground; }
            set
            {
                Model.saturdayBackground = value;
                OnPropertyChanged();
            }
        }

        public Brush _sundayBackground
        {
            get { return Model.sundayBackground; }
            set
            {
                Model.sundayBackground = value;
                OnPropertyChanged();
            }
        }

        public string _selectedDay
        {
            get { return Model.selectedDay; }
            set
            {
                Model.selectedDay = value;
                OnPropertyChanged();
            }
        }
        public ICommand exerciseChangeColorCommand { get; set; }

        public void exerciseChangeColor(object obj)
        {
            _selectedDay = obj.ToString();
            switch (_selectedDay)
            {
                case "monday":
                    _mondayBackground = Brushes.Gray;
                    _tuesdayBackground = Brushes.White;
                    _wednesdayBackground = Brushes.White;
                    _thursdayBackground = Brushes.White;
                    _fridayBackground = Brushes.White;
                    _saturdayBackground = Brushes.White;
                    _sundayBackground = Brushes.White;
                    break;
                case "tuesday":
                    _mondayBackground = Brushes.White;
                    _tuesdayBackground = Brushes.Gray;
                    _wednesdayBackground = Brushes.White;
                    _thursdayBackground = Brushes.White;
                    _fridayBackground = Brushes.White;
                    _saturdayBackground = Brushes.White;
                    _sundayBackground = Brushes.White;
                    break;
                case "wednesday":
                    _mondayBackground = Brushes.White;
                    _tuesdayBackground = Brushes.White;
                    _wednesdayBackground = Brushes.Gray;
                    _thursdayBackground = Brushes.White;
                    _fridayBackground = Brushes.White;
                    _saturdayBackground = Brushes.White;
                    _sundayBackground = Brushes.White;
                    break;
                case "thursday":
                    _mondayBackground = Brushes.White;
                    _tuesdayBackground = Brushes.White;
                    _wednesdayBackground = Brushes.White;
                    _thursdayBackground = Brushes.Gray;
                    _fridayBackground = Brushes.White;
                    _saturdayBackground = Brushes.White;
                    _sundayBackground = Brushes.White;
                    break;
                case "friday":
                    _mondayBackground = Brushes.White;
                    _tuesdayBackground = Brushes.White;
                    _wednesdayBackground = Brushes.White;
                    _thursdayBackground = Brushes.White;
                    _fridayBackground = Brushes.Gray;
                    _saturdayBackground = Brushes.White;
                    _sundayBackground = Brushes.White;
                    break;
                case "saturday":
                    _mondayBackground = Brushes.White;
                    _tuesdayBackground = Brushes.White;
                    _wednesdayBackground = Brushes.White;
                    _thursdayBackground = Brushes.White;
                    _fridayBackground = Brushes.White;
                    _saturdayBackground = Brushes.Gray;
                    _sundayBackground = Brushes.White;
                    break;
                case "sunday":
                    _mondayBackground = Brushes.White;
                    _tuesdayBackground = Brushes.White;
                    _wednesdayBackground = Brushes.White;
                    _thursdayBackground = Brushes.White;
                    _fridayBackground = Brushes.White;
                    _saturdayBackground = Brushes.White;
                    _sundayBackground = Brushes.Gray;
                    break;
                default:
                    break;
            
            }

        }

        public ObservableCollection<string> _mondayList
        {
            get
            {
                return Model.mondayList;
            }
            set
            {
                Model.mondayList = value;
            }
        }
        public ObservableCollection<string> _tuesdayList
        {
            get
            {
                return Model.tuesdayList;
            }
            set
            {
                Model.tuesdayList = value;
            }
        }
        public ObservableCollection<string> _wednesdayList
        {
            get
            {
                return Model.wednesdayList;
            }
            set
            {
                Model.wednesdayList = value;
            }
        }
        public ObservableCollection<string> _thursdayList
        {
            get
            {
                return Model.thursdayList;
            }
            set
            {
                Model.thursdayList = value;
            }
        }
        public ObservableCollection<string> _fridayList
        {
            get
            {
                return Model.fridayList;
            }
            set
            {
                Model.fridayList = value;
            }
        }

        public ObservableCollection<string> _saturdayList
        {
            get
            {
                return Model.saturdayList;
            }
            set
            {
                Model.saturdayList = value;
            }
        }
        public ObservableCollection<string> _sundayList
        {
            get
            {
                return Model.sundayList;
            }
            set
            {
                Model.sundayList = value;
            }
        }

        public ICommand addExerciseCommand { get; set; }

        public void addExercise(object obj)
        {
            switch (_selectedDay)
            {
                case "monday":
                    _mondayList.Add(obj.ToString());
                    break;
                case "tuesday":
                    _tuesdayList.Add(obj.ToString());
                    break;
                case "wednesday":
                    _wednesdayList.Add(obj.ToString());
                    break;
                case "thursday":
                    _thursdayList.Add(obj.ToString());
                    break;
                case "friday":
                    _fridayList.Add(obj.ToString());
                    break;
                case "saturday":
                    _saturdayList.Add(obj.ToString());
                    break;
                case "sunday":
                    _sundayList.Add(obj.ToString());
                    break;

                default:
                    _mondayList.Add(obj.ToString());
                    break;
            }

        }
        public ICommand saveExerciseCommand { get; set; }

        public void saveExercise(object obj)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, "||||||||Menedżer Kalorii|||||||| \n\n|Poniedziałek| \n" + writeOut(_mondayList) + "\n|Wtorek|\n" + writeOut(_tuesdayList) + "\n|Środa|\n" + writeOut(_wednesdayList) + "\n|Czwartek|\n" + writeOut(_thursdayList) + "\n|Piątek|\n" + writeOut(_fridayList) + "\n|Sobota|\n" + writeOut(_saturdayList) + "\n|Niedziela|\n" + writeOut(_sundayList));
            }

        }

        public ICommand removeLastExerciseCommand { get; set; }

        public void removeLastExercise(object obj)
        {
            switch (_selectedDay)
            {
                case "monday":
                    if (_mondayList.Count > 0)
                        _mondayList.RemoveAt(_mondayList.Count - 1);
                    break;
                case "tuesday":
                    if (_tuesdayList.Count > 0)
                        _tuesdayList.RemoveAt(_tuesdayList.Count - 1);
                    break;
                case "wednesday":
                    if (_wednesdayList.Count > 0)
                        _wednesdayList.RemoveAt(_wednesdayList.Count - 1);
                    break;
                case "thursday":
                    if (_thursdayList.Count > 0)
                        _thursdayList.RemoveAt(_thursdayList.Count - 1);
                    break;
                case "friday":
                    if (_fridayList.Count > 0)
                        _fridayList.RemoveAt(_fridayList.Count - 1);
                    break;
                case "saturday":
                    if (_saturdayList.Count > 0)
                        _saturdayList.RemoveAt(_saturdayList.Count - 1);
                    break;
                case "sunday":
                    if (_sundayList.Count > 0)
                        _sundayList.RemoveAt(_sundayList.Count - 1);
                    break;

                default:
                    if (_mondayList.Count > 0)
                        _mondayList.RemoveAt(_mondayList.Count - 1);
                    break;
            }
        }

    }
}
