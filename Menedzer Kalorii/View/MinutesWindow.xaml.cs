using Menedzer_Kalorii.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Menedzer_Kalorii.View
{
    /// <summary>
    /// Interaction logic for MinutesWindow.xaml
    /// </summary>
    public partial class MinutesWindow : Window
    {
        public MinutesWindow()
        {
            InitializeComponent();
            DataContext = new MinutesWindowViewModel();
        }
    }
}
