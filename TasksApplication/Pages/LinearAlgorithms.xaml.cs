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

namespace TasksApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для LinearAlgorithms.xaml
    /// </summary>
    public partial class LinearAlgorithms : Page
    {
        public LinearAlgorithms()
        {
            InitializeComponent();
        }

        private void TbValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse((sender as TextBox).Text, out int x))
            {

            }
            else
                MessageBox.Show("Неверное значение X");
        }
    }
}
