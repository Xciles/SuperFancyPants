using System.ComponentModel.DataAnnotations;

namespace SuperUserWeb.Domain.Enums
{
    public enum ESize
    {
        [Display(Name = "One Person")]
        OnePerson = 0,
        [Display(Name = "Two Persons")]
        TwoPerson = 1,
    }
}