using System.Drawing;
using System.Net.Mime;
using System.Windows.Media;
using WpfApp8.Models;
using Color = System.Windows.Media.Color;

namespace WpfApp8.Logic;

public class WooManBmi : BaseBmi
{
    public override string GetRecomandation(double bmi)
    {
        switch (bmi)
        {
            case < 18.3:
                return "Недостаток веса. \nРекмондуется повысить массу тела";
            case >= 18.3 and < 24.6:
                return "Норма веса.";
            case >= 24.6 and < 29:
                return "Избыток веса. \nРекомендуется снизить массу тела!";
            case > 29:
                return "Ожирение. \nНастоятельно рекомендуется снизить массу тела!";
            default:
                return "Ошибка";
        }
        
        return String.Empty;
    }

    
}