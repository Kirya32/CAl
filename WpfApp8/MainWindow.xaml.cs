﻿using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp8;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    
    public MainWindow()
    {
        InitializeComponent();
        Gender.ItemsSource = Enum.GetValues(typeof(Gender)).Cast<Gender>();
    }
    private double CalculateIdealWeight(double bel,double height,double age,double weight,string activity, string gender, string task)
    {
        double bju;
        double bmi;
        string result = null;
        //bju = (10 * weight + 6.25 * height + 5 * age + gender) + activity;
            bmi = (weight / (height * height)) * 10000;
        switch (gender)
        {
            case "Мужской":
                switch (bmi)
                
                {
                    case < 18.5:
                        Foreground = Brushes.DarkGreen;
                        result = "Недостаток веса. \nРекмондуется повысить массу тела";
                        break;
                    case >= 18.5 and < 24.9:
                        Foreground = Brushes.LimeGreen;
                        result = "Норма веса.";
                        break;
                    case >= 24.9 and < 29.9:
                        Foreground = Brushes.Orange;
                        result = "Избыток веса. \nРекомендуется снизить массу тела!";
                        break;
                    case > 29.9:
                        Foreground = Brushes.Red;
                        result = "Ожирение. \nНастоятельно рекомендуется снизить массу тела!";
                        break;
                    default:
                        result = "Ошибка";
                        break;
                }

                break;
            case "Женский":
                switch (bmi)
                {
                    case < 18.5:
                        Foreground = Brushes.DarkGreen;
                        result = "Недостаток веса. \nРекмондуется повысить массу тела";
                        break;
                    case >= 18.5 and < 25:
                        Foreground = Brushes.LimeGreen;
                        result = "Норма веса.";
                        break;
                    case >= 25 and < 30:
                        Foreground = Brushes.Orange;
                        result = "Избыток веса. \nРекомендуется снизить массу тела!";
                        break;
                    case > 30:
                        Foreground = Brushes.Red;
                        result = "Ожирение. \nНастоятельно рекомендуется снизить массу тела!";
                        break;
                    default:
                        result = "Ошибка";
                        break;
                }

                break;
            default:
                MessageBox.Show("Выберите существующий гендер");
                break;
        }
        resultTB.Text = $"Ваш ИМТ: {bmi:F2}. + У вас {result}.";
        return 0;
    }

    private void Btnx_OnClick(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(heightBT.Text, out double height) && double.TryParse(weightBT.Text, out double weight) && double.TryParse(ageTB.Text, out double age) 
            && double.TryParse(BelTB.Text, out double bel))
        {
            string activity = Activity.SelectionBoxItem as string;
            string gender = Gender.SelectionBoxItem as string;
            string task = Task.SelectionBoxItem as string;
            CalculateIdealWeight(bel, height, age, weight, activity, gender, task);
        }
        else
        {
            MessageBox.Show("Поля не должен быть пустым!");
        }
    }
}