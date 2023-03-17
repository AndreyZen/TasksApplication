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
    /// Логика взаимодействия для SubprogrammPage.xaml
    /// </summary>
    public partial class SubprogrammPage : Page
    {
        private double MinX = Math.PI / 5, MaxX = (4 * Math.PI) / 5;
        public SubprogrammPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Сортировка массива по убыванию
        /// </summary>
        /// <param name="a">Массив вещественных чисел</param>
        /// <param name="n">Размерность массива</param>
        /// <returns>Сортированый массив</returns>
        private uint[] SortElem(uint[] a, int n)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    if (j + 1 < a.Length && a[j] > a[j + 1])
                    {
                        uint tmp = a[j];

                        a[j] = a[j + 1];

                        a[j + 1] = tmp;
                    }
                }
            }

            return a;
        }

        private void BtnSort_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbArrValue.Text))
            {
                TbSortArr.Text = "Значения не введены";
                return;
            }    

            string[] str = TbArrValue.Text.Split(' ');
            uint[] values = new uint[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                if (uint.TryParse(str[i], out uint n))
                {
                    values[i] = n;
                }
                else
                {
                    TbSortArr.Text = "Введены не верные значения";
                    return;
                }
            }

            values = SortElem(values, values.Length);
            TbSortArr.Text = null;
            foreach (var item in values)
            {
                TbSortArr.Text += item + " ";
            }
        }

        private void BtnCalculation_Click(object sender, RoutedEventArgs e)
        {
            //Минимальное и максимальное значение X
            double MinX = Math.PI / 5, MaxX = (4 * Math.PI) / 5, StepX = (MaxX - MinX) / 10;
            //Создаем 2 массива
            double[] PointsY = new double[10], PointsX = new double[10];

            //Получаем значение у
            for (int i = 0; i < PointsY.Length; i++)
            {
                if (i != 0)
                    //Если итератор не 0, прибавляем к минимальному х шаг, уноженный на количество итераций
                    PointsX[i] = (MinX + (StepX * (i + 1))) / 2;
                else
                    //Если итератор 0, используем минимальное значение х
                    PointsX[i] = MinX / 2;
            }
            //Получаем значение S
            for (int i = 0; i < PointsY.Length; i++)
            {
                //Если итератор не 0, прибавляем к минимальному х шаг, уноженный на количество итераций
                if (i != 0)
                    //К синусу х прибавляем полученные S значения
                    PointsY[i] = Math.Sin((MinX + (StepX * (i + 1)))) + GetSValue(40, (MinX + (StepX * (i + 1))));
                else
                    PointsY[i] = Math.Sin(MinX) + GetSValue(40, MinX);
            }

            TbNumbersY.Text = null;
            foreach (var x in PointsX)
            {
                TbNumbersY.Text += x.ToString() + " ";
            }

            TbNumbersS.Text = null;
            foreach (var s in PointsY)
            {
                TbNumbersS.Text += s.ToString() + " ";
            }
        }

        /// <summary>
        /// Получение значений S
        /// </summary>
        /// <param name="n">Количество итераций</param>
        /// <param name="x">Текущее значение х</param>
        /// <returns></returns>
        private double GetSValue(int n, double x)
        {
            //Если значение итерации больше 0
            if (n > 0)
            {
                //Возвращаем значение расчета + рекурсивный вызов функции
                return Math.Pow(-1, n + 1) * (Math.Sin(n * x) / n) + GetSValue(--n, x);
            }
            else
                //Если значение итератора равно 0, возвращаем 0
                return 0;
        }
    }
}
