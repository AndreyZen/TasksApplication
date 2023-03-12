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
    /// Логика взаимодействия для CyclicAlgorithms.xaml
    /// </summary>
    public partial class CyclicAlgorithms : Page
    {
        public CyclicAlgorithms()
        {
            InitializeComponent();
        }

        private void TbValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(TbValue.Text, out int value))
            {
                string ternaryNumbers = new string(TernaryNumberCounter(value).ToCharArray().Reverse().ToArray());
                TbTernaryNumber.Text = ternaryNumbers;
                TbUnitCount.Text = ternaryNumbers.Split('1').Length == 1 ? "1" : (ternaryNumbers.Split('1').Length - 1).ToString();
            }
            else
            {
                TbTernaryNumber.Text = "0";
                TbUnitCount.Text = "0";
            }
        }

        private string TernaryNumberCounter(int n)
        {
            if ((n / 3) == 0)
                return (n % 3).ToString();

            return (n % 3).ToString() + TernaryNumberCounter((n / 3));
        }

        private void TbValueX_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(TbValueX.Text, out int x) && int.TryParse(TbValueY.Text, out int y))
            {
                TbResult.Text = GetMathFormulValue(x, y);
            }
            else
                TbResult.Text = "Введены не корректные значения";
        }

        private string GetMathFormulValue(int x, int y)
        {
            if (x < 0 || y < 0)
                return "Числа не являются положительными";

            double intermedate, result = 1;

            for (int k = 1; k <= 15; k++)
            {
                intermedate = 0;
                for (int i = k + 1; i <= 7; i++)
                {
                    intermedate += 4 * Math.Pow(y, k);
                }

                result *= Math.Sqrt(x) * intermedate == 0 ? 1 : intermedate;
            }

            return result.ToString();
        }
    }
}
