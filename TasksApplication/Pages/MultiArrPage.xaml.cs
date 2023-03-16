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
        private int[,] GetMatrinxByMN(int n, int m)
        {
            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = _rnd.Next(100);
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
                textMatrix += Environment.NewLine;
            }
            return textMatrix;
        }
        private void BtnNewMatrix_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TbValueN.Text, out int n) && int.TryParse(TbValueM.Text, out int m))
            {
                MnMatrix = GetMatrinxByMN(n, m);
                TbMatrixNM.Text = UploadNmMatrixText(MnMatrix);
            }
        }
         
        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMatrixGenerate_Click(object sender, RoutedEventArgs e)
        {

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

            int[] MaxLine = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                MaxLine[i] = matrix[RowIndex, i];
            }

            Array.Sort(MaxLine);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[RowIndex, i] = MaxLine[i];
            }

            TbResultMNMatrix.Text = UploadNmMatrixText(matrix);
        }
    }
}
