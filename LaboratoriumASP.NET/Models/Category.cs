using System.ComponentModel.DataAnnotations;

namespace LaboratoriumASP.NET.Models;

public enum Category
{
    [Display(Name = "Rodzina")]
    Family = 1,
    [Display(Name = "Znajomy")]
    Friend = 2,
    [Display(Name = "Kontakt zawodowy")]
    Business = 4
}