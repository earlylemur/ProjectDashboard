using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ProjectDashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = new MainWindowViewModel();
            
        }



        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            VM.SetProject();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_WebLaunch_Click(object sender, RoutedEventArgs e)
        {
            VM.SelectedWebPath.Launch();
        }

        private void Btn_FolderLaunch_Click(object sender, RoutedEventArgs e)
        {
            VM.SelectedFolderPath.Launch();
        }

        private void Btn_SoftwLaunch_Click(object sender, RoutedEventArgs e)
        {
            VM.SelectedSoftwarePath.Launch();
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (VM.CurrentProject != null && !String.IsNullOrEmpty(VM.CurrentProject.Label))
            {
                FileIO.WriteToFile(VM.CurrentProject);
            }
        }
    }
}
