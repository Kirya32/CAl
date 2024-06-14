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

    private double CalculateIdealWeight(double height, string gender)
    {
        switch (gender)
        {
            case "Мужской":
                return (height - 100) - (height - 150) / 4;
            case "Женский":
                return (height - 100) - (height - 150) / 2;
            case "Иной":
                MessageBox.Show("Выберите существующий гендер");
                break;
        }
        return 0;
    }

    private void Btnx_OnClick(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(heightBT.Text, out double height) && height > 0)
        {
            string gender = Gender.SelectionBoxItem as string;
            double idealWeight = CalculateIdealWeight(height, gender);
            result.Content = $"Ваш идеальный вес: {idealWeight:F2} кг";
        }
        else
        {
            MessageBox.Show("Введите рост");
        }
    }
}