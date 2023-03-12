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
    /// Логика взаимодействия для BranchedAlgorithms.xaml
    /// </summary>
    public partial class BranchedAlgorithms : Page
    {
        public BranchedAlgorithms()
        {
            InitializeComponent();
        }

        private void TbValueDay_TextChanged(object sender, TextChangedEventArgs e)
        {
            string day;
            switch (TbValueDay.Text)
            {
                case "1":
                    day = "Понедельник";
                    break;
                case "2":
                    day = "Вторник";
                    break;
                case "3":
                    day = "Среда";
                    break;
                case "4":
                    day = "Четверг";
                    break;
                case "5":
                    day = "Пятница";
                    break;
                case "6":
                    day = "Суббота";
                    break;
                case "7":
                    day = "Воскресенье";
                    break;
                case "":
                    TbDay.Text = null;
                    return;
                default:
                    TbDay.Text = TbValueDay.Text + " не является днем";
                    return;
            }
            TbDay.Text = day;
        }

        private void TbValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbValue.Text))
                TbNumbers.Text = null;
            else
                TbNumbers.Text = Calculation(TbValue.Text);
        }

        private string Calculation(string value)
        {
            //Если число не целое или не число, выдаем ошибку
            if (int.TryParse(value, out int result))
            {
                //Убираем знак
                result = Math.Abs(result);

                //Если длина числа больше двух, выдаем ошибку
                if (result.ToString().Length != 2)
                    return "Число не является дузначным";

                //Если число не является восьмиричным, выдаем ошибку
                if ((result / 10) >= 8 || (result / 10) < 0 || (result % 10) >= 8 || (result % 10) < 0)
                    return "Число не является восьмиричным";


                switch (Math.Max((result / 10), (result % 10)))
                {
                    case 0:
                        value = "Ноль";
                        break;
                    case 1:
                        value = "Один";
                        break;
                    case 2:
                        value = "Два";
                        break;
                    case 3:
                        value = "Три";
                        break;
                    case 4:
                        value = "Четыре";
                        break;
                    case 5:
                        value = "Пять";
                        break;
                    case 6:
                        value = "Шесть";
                        break;
                    case 7:
                        value = "Семь";
                        break;
                    default:
                        break;
                }
                switch (Math.Min((result / 10), (result % 10)))
                {
                    case 0:
                        value += " Zero";
                        break;
                    case 1:
                        value += " One";
                        break;
                    case 2:
                        value += " Two";
                        break;
                    case 3:
                        value += " Three";
                        break;
                    case 4:
                        value += " Four";
                        break;
                    case 5:
                        value += " Five";
                        break;
                    case 6:
                        value += " Six";
                        break;
                    case 7:
                        value += " Seven";
                        break;
                    default:
                        break;
                }

                return value;
            }
            else
                return "Ошибка ввода";
        }
    }
}
