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
    /// Логика взаимодействия для ArrayPage.xaml
    /// </summary>
    public partial class ArrayPage : Page
    {
        public ArrayPage()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            TbResult.Text = null;

            decimal[] arr = GetArrDecimalFromString(TbValues.Text);
            if (arr != null)
            {
                var result = GetIndexesOfMinMaxElement(arr);
                arr[result.Item1] = arr[result.Item1] / 2;
                arr[result.Item2] = arr[result.Item2] * 2;
                foreach (var item in arr)
                {
                    TbResult.Text += item.ToString() + ' ';
                }
            }
            else
                TbResult.Text = "Введены не верные значения";
        }

        private decimal[] GetArrDecimalFromString(string str, int n = 10)
        {
            try
            {
                decimal[] arr = new decimal[n];
                string[] arrStr = str.Replace('.', ',').Split(' ');
                for (int i = 0; i < arrStr.Length; i++)
                {
                    if (decimal.TryParse(arrStr[i], out decimal d))
                    {
                        arr[i] = d;
                    }
                    else
                        return null;
                }
                return arr;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static (int, int) GetIndexesOfMinMaxElement(decimal[] array, int multiple = 1)
        {
            decimal minElement = array[0], maxElement = array[0];
            var result = (-1, -1);

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % multiple != 0)
                    break;

                if (array[i] <= minElement)
                {
                    minElement = array[i];
                    result.Item1 = i;
                }
                if (array[i] >= maxElement)
                {
                    maxElement = array[i];
                    result.Item2 = i;
                }
            }

            return result;
        }

        private int[] GetIntArrFromString(string str, int n)
        {
            try
            {
                int[] arr = new int[n];
                string[] arrStr = str.Split(' ');
                for (int i = 0; i < arrStr.Length; i++)
                {
                    if (int.TryParse(arrStr[i], out int d))
                    {
                        arr[i] = d;
                    }
                    else
                        return null;
                }
                return arr;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void BtnCalculateSecond_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TbValueN.Text, out int n))
            {
                if (n >= 0)
                {
                    int[] a = GetIntArrFromString(TbArrayAValues.Text, n), b = GetIntArrFromString(TbArrayBValues.Text, n);
                    if (a != null && b != null)
                    {
                        var indexes = GetIndexesOfMinMaxElement(GetArrDecimalFromString(TbArrayBValues.Text, n), 5);
                        if (indexes.Item1 != -1 && indexes.Item2 != -1)
                        {
                            int sum = b[indexes.Item1] + b[indexes.Item2];

                            TbResultSecond.Text = null;

                            for (int i = 0; i < a.Length; i++)
                            {
                                if (a[i] > sum)
                                    TbResultSecond.Text += a[i].ToString() + " ";
                            }

                            if (string.IsNullOrWhiteSpace(TbResultSecond.Text))
                                TbResultSecond.Text = "Таких чисел нет";
                        }
                        else
                            TbResultSecond.Text = "Таких чисел нет";
                    }
                    else
                        TbResultSecond.Text = "Введены не корректные значения";
                }
                else
                    TbResultSecond.Text = "n - не является натуральным числом";
            }
            else
                TbResultSecond.Text = "n - не является натуральным числом";
        }


    }
}
