using System.ComponentModel.Design;
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
using WpfApp8.Logic;

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
            var bmiController = new ManBmi();
            bmi = bmiController.Calc(weight, height);
            result = bmiController.GetRecomandation(bmi);
        }
        else
        {
            var bmiController = new WooManBmi();
            bmi = bmiController.Calc(weight, height); 
            result = bmiController.GetRecomandation(bmi);
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