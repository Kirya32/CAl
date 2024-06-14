using System.Runtime.Intrinsics.X86;
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
    }
    private double CalculateIdealWeight(double height, string gender, double weight)
    {
        double bmi;
        string result = null;
        bmi = (weight / (height * height)) * 10000;
        if (gender == "Мужской")
        {
            if (bmi < 18.5)
                result = "Недостаток веса";
            else if (bmi >= 18.5 && bmi < 24.9)
                result = "Норма веса";
            else if (bmi >= 24.9 && bmi < 29.9)
                result = "Избыточный вес";
            else if (bmi > 29.9)
                result = "Ожирение";
            else
                result = "Ошибка"; 
        }
        else if (gender == "Женский")
        {
            if (bmi < 18.5)
                result = "Недостаток веса";
            else if (bmi >= 18.5 && bmi < 25)
                result = "Норма веса";
            else if (bmi >= 25 && bmi < 30)
                result = "Избыток веса";
            else if (bmi > 30)
                result = "Ожирение";
            else
                result = "Ошибка";
        }
        else
        {
            MessageBox.Show("Выберите существующий гендер");
        }
        resultTB.Text = $"Ваш ИМТ: {bmi:F2}. + У вас {result}.";
        return 0;
    }

    private void Btnx_OnClick(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(heightBT.Text, out double height) && double.TryParse(weightBT.Text, out double weight))
        {
            string gender = Gender.SelectionBoxItem as string;
            CalculateIdealWeight(height, gender, weight);
        }
        else
        {
            MessageBox.Show("Рост и/или вес не должен быть пустим!");
        }
    }
}