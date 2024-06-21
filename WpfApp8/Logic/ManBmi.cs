using System.Windows.Media;

namespace WpfApp8.Logic;

public class ManBmi : BaseBmi
{
    public override string GetRecomandation(double bmi)
    {
        switch (bmi)
        {
            case < 18.5:
                return "Недостаток веса. \nРекмондуется повысить массу тела";
            case >= 18.5 and < 24.9:
                return "Норма веса.";
            case >= 24.9 and < 29.9:
                return "Избыток веса. \nРекомендуется снизить массу тела!";
            case > 29.9:
                return "Ожирение. \nНастоятельно рекомендуется снизить массу тела!";
        }
        
        return String.Empty;
    }
}