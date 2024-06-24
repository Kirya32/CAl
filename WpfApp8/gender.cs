using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WpfApp8;

public enum Gender
{
    [Display(Name="Муж")]
    Male, 
    [Display(Name="Жен")]
    Female
}