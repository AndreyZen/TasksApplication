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
    /// Логика взаимодействия для MultiArrPage.xaml
    /// </summary>
    public partial class MultiArrPage : Page
    {
        private readonly Random _rnd;
        private int[,] MnMatrix;
        private double[,] Matrix;
        public MultiArrPage()
        {
            _rnd = new Random();
            InitializeComponent();
        }

        /// <summary>
        /// Генерация целочисленной матрицы размерностью n, m
        /// </summary>
        /// <param name="n">Количество строк матрицы</param>
        /// <param name="m">Количество столбцов матрицы</param>
        /// <returns></returns>
        private int[,] GetMatrinxByMN(int n, int m, int min = 10, int max = 100)
        {
            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = _rnd.Next(min, max);
                }
            }
            return matrix;
        }
        /// <summary>
        /// Генерация вещественной матрицы
        /// </summary>
        /// <param name="n">Кол-во строк</param>
        /// <param name="m">Кол-во столбцов</param>
        /// <returns></returns>
        private double[,] GetRealMatrix(int n, int m)
        
        {
            double[,] matrix = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = Math.Round(_rnd.NextDouble(), 2);
                    if(_rnd.NextDouble() >= 0.8)
                        matrix[i, j] = matrix[i, j] * -1;
                }
            }
            return matrix;
        }

        /// <summary>
        /// Вывод матрицы N, M в текстовое поле
        /// </summary>
        /// <param name="matrix">Матрица N, M</param>
        private string UploadNmMatrixText(int[,] matrix)
        {
            string textMatrix = null;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    textMatrix += matrix[i, j] + " ";
                }
                if (i != matrix.GetLength(0) - 1)
                    textMatrix += Environment.NewLine;
            }
            return textMatrix;
        }

        private string UploadNmMatrixText(double[,] matrix)
        {
            string textMatrix = null;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    textMatrix += matrix[i, j].ToString().PadRight(6);
                }
                if (i != matrix.GetLength(0) - 1)
                    textMatrix += Environment.NewLine;
            }
            return textMatrix;
        }
        private void BtnNewMatrix_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TbValueN.Text, out int n) && int.TryParse(TbValueM.Text, out int m) && n > 0 && m > 0)
            {
                MnMatrix = GetMatrinxByMN(n, m);
                TbMatrixNM.Text = UploadNmMatrixText(MnMatrix);
                BrdGrid.Visibility = Visibility.Visible;
            }
        }

        private void BtnMatrixGenerate_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                Matrix = GetRealMatrix(5, 5);
            }
            while (Matrix.Cast<double>().Where(p => p == Matrix.Cast<double>().Min()).Count() != 1);
            TbMatrix.Text = UploadNmMatrixText(Matrix);
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int ColumnIndex = 0;
            double MinValue = Matrix[0, 0];

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (Matrix[i, j] < MinValue)
                    {
                        MinValue = Matrix[i, j];
                        ColumnIndex = j;
                    }
                }
            }

            int ValuesCount = 0;
            double ValuesMul = 1;
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                if (Matrix[i, ColumnIndex] >= 0)
                {
                    ValuesCount++;
                    ValuesMul *= Matrix[i, ColumnIndex];
                }
            }

            TbResult.Text = Math.Pow(ValuesMul, 1.0 / ValuesCount).ToString();
        }





        private void BtnCalculateSecond_Click(object sender, RoutedEventArgs e)
        {
            int RowIndex = 0, MaxValue = 0;

            int[,] matrix = MnMatrix;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int NewMaxValue = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    NewMaxValue += matrix[i, j];
                }
                if (NewMaxValue > MaxValue)
                {
                    MaxValue = NewMaxValue;
                    RowIndex = i;
                }
            }

            int[] MaxLine = new int[matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                MaxLine[i] = matrix[RowIndex, i];
            }

            Array.Sort(MaxLine);

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[RowIndex, i] = MaxLine[i];
            }

            TbResultMNMatrix.Text = UploadNmMatrixText(matrix);
        }
    }
}
