using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
