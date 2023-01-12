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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfTeam04.IndividueleOpdrachten;
using WpfTeam04.Project;
using WpfTeam04.TestingDBboeken;

namespace WpfTeam04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml  hallo 
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();       
          
        }

        private void MnuSettings_Click(object sender, RoutedEventArgs e)
        {
            var wpf = new WpfSettings();
            wpf.ShowDialog();
        }

        private void MnuVahidB_Khosrowshahi_Click(object sender, RoutedEventArgs e)
        {
            var wpfVahid = new WpfVahidBaradarkhodam();
            wpfVahid.ShowDialog();
        }

        private void MnuHassan_Click(object sender, RoutedEventArgs e)
        {
            var wpfHassan = new WpfHassanAli();
            wpfHassan.ShowDialog();
        }

        private void MnuElke_Click(object sender, RoutedEventArgs e)
        {
            // var wpfHassan = new WpfElkeSleven();
            // wpfHassan.ShowDialog();
        }
        private void MnuZander_Click(object sender, RoutedEventArgs e)
        {
            // var wpfHassan = new WpfZanderCapuzzimati();
            // wpfHassan.ShowDialog();
        }

        private void BoekenData_Click(object sender, RoutedEventArgs e)
        {
            var wpfBoekData = new TestBoekData();
            wpfBoekData.ShowDialog();
        }

        private void KlantenData_Click(object sender, RoutedEventArgs e)
        {
            var wpfKlantData = new WpfKlanten();
            wpfKlantData.ShowDialog();
        }
    }
}
