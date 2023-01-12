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

namespace WpfTeam04.Project
{
    /// <summary>
    /// Interaction logic for WpfDashboard.xaml
    /// </summary>
    public partial class WpfDashboard : Window
    {
        public WpfDashboard()
        {
            InitializeComponent();

            
        }

        private void btnWpflogin_Click(object sender, RoutedEventArgs e)
        {
            Wpflogin wpflogin = new Wpflogin();
            wpflogin.ShowDialog();
        }

        private void btnWpfSettings_Click(object sender, RoutedEventArgs e)
        {
            WpfSettings wpfSettings = new WpfSettings();
            wpfSettings.ShowDialog();
        }

       
      

        private void btnMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wpfMainWindow = new MainWindow();
            wpfMainWindow.ShowDialog();
        }

    
    }
}
