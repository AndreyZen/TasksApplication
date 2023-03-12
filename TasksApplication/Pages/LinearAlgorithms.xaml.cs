using System;
using System.Windows.Controls;

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
            if (long.TryParse(TbValueX.Text, out long x))
            {
                TbRnF.Text = Math.Pow((x + Math.Log(x)), 1.0 / 3.0).ToString();
                if (long.TryParse(TbValueY.Text, out long y))
                    TbRnG.Text = Math.Abs(Math.Pow(y, 5) - x + Math.Sin(Math.Pow(x, 2))).ToString();
                else
                    TbRnG.Text = "0";
            }
            else
            {
                TbRnG.Text = "0";
                TbRnF.Text = "0";
            }
        }

        private void TbValueSum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(int.TryParse(TbValueSum.Text, out int x))
            {
                double sum = ((x / 100) + (x % 100 / 10) + (x % 10)) / 3.0; 
                TbRnFullValue.Text = sum.ToString();
                TbRn.Text = ((int)(sum * 100 % 10)).ToString();
            }
            else
            {
                TbRnFullValue.Text = "0";
                TbRn.Text = "0";
            }
        }
    }
}
