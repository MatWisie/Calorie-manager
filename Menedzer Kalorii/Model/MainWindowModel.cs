using Menedzer_Kalorii.Properties;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Menedzer_Kalorii.Model
{
    class MainWindowModel
    {
        
       public DateTime _date;

        public double _weight;
        public double _height;
        public double? _bmi = null;
        public string _verdict = null;
        public ObservableCollection<string> foodList = new ObservableCollection<string>(){};
        public double kcal;
        public int grams;
        public string selectedcategory;
        public ObservableCollection<string> breakfastList = new ObservableCollection<string>() { };
        public ObservableCollection<string> lunchList = new ObservableCollection<string>() { };
        public ObservableCollection<string> supperList = new ObservableCollection<string>() { };
        public Brush breakfastBackground;
        public Brush lunchBackground;
        public Brush supperBackground;
        public int minutes;
        public double burnedCalories;
        public ObservableCollection<string> exercisesList = new ObservableCollection<string>() { };
        public Brush mondayBackground;
        public Brush tuesdayBackground;
        public Brush wednesdayBackground;
        public Brush thursdayBackground;
        public Brush fridayBackground;
        public Brush saturdayBackground;
        public Brush sundayBackground;
        public string selectedDay;
        public ObservableCollection<string> mondayList = new ObservableCollection<string>() { };
        public ObservableCollection<string> tuesdayList = new ObservableCollection<string>() { };
        public ObservableCollection<string> wednesdayList = new ObservableCollection<string>() { };
        public ObservableCollection<string> thursdayList = new ObservableCollection<string>() { };
        public ObservableCollection<string> fridayList = new ObservableCollection<string>() { };
        public ObservableCollection<string> saturdayList = new ObservableCollection<string>() { };
        public ObservableCollection<string> sundayList = new ObservableCollection<string>() { };
        public PlotModel bmiPlotModel;
       public MainWindowModel()
        {
            bmiPlotModel = new PlotModel();
            bmiPlotModel.Series.Add(new LineSeries());
            if (Settings.Default.BMI != null)
                for (int a = 1; a <= 31; a++)
                (bmiPlotModel.Series[0] as LineSeries).Points.Add(new DataPoint(a, Convert.ToDouble(Settings.Default.BMI[a])));
        }

        public void saveBMI()
        {
            int currentDaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year,DateTime.Now.Month);
            int currentDay = DateTime.Now.Day;

            if (Settings.Default.BMI == null)
            {
                var newList = new ArrayList();
                for (int i = 0; i < 32; i++)
                    newList.Add(0.0);
                Settings.Default.BMI = newList;
                Settings.Default.BMI[currentDay] = _bmi;
                Settings.Default.Save();
            }
            else
            {
                if (Convert.ToDouble(Settings.Default.BMI[currentDaysInMonth]) == 0)
                {
                    Settings.Default.BMI[currentDay] = _bmi;
                    Settings.Default.Save();
                }
                else
                {
                    Settings.Default.Reset();
                    Settings.Default.BMI[currentDay] = _bmi;
                    Settings.Default.Save();
                }
            }
            
            
        }
    }
}
