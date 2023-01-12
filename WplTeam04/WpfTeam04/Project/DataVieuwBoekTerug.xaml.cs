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
    /// Interaction logic for DataVieuwBoekTerug.xaml
    /// </summary>
    public partial class DataVieuwBoekTerug : Window
    {
        public DataVieuwBoekTerug(boekTerug xx)
        {
            InitializeComponent();

            boekTerug x = xx as boekTerug;


        }
    }
}
