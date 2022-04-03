using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
