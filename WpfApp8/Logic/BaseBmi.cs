namespace WpfApp8.Logic;

public class BaseBmi
{
    public virtual double Calc(double weight, double hegiht)
    {
        return (weight / (hegiht * hegiht)) * 10000;
    }

    public virtual string GetRecomandation(double bmi)
    {
        return "";
    }
}