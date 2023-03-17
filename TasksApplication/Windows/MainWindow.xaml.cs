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

namespace TasksApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void CbPages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CbPages.SelectedIndex)
            {
                case 0:
                    MainFrame.Navigate(new Pages.LinearAlgorithms());
                    break;
                case 1:
                    MainFrame.Navigate(new Pages.BranchedAlgorithms());
                    break;
                case 2:
                    MainFrame.Navigate(new Pages.CyclicAlgorithms());
                    break;
                case 3:
                    MainFrame.Navigate(new Pages.ArrayPage());
                    break;
                case 4:
                    MainFrame.Navigate(new Pages.MultiArrPage());
                    break;
                case 5:
                    MainFrame.Navigate(new Pages.SubprogrammPage());
                    break;
                default:
                    break;
            }
        }
    }
}
