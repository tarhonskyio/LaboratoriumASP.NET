using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratoriumASP.NET.Models;
[Table("contacts")]
public class ContactEntity
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(length:20)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(length:50)]
    public string LastName { get; set; }
    
    public string Email { get; set; }
    [MaxLength(12)]
    [MinLength(9)]
    public string PhoneNumber { get; set; }
    
    public Category Category { get; set; }
    
    public DateOnly BirthDate { get; set; }
    
    public DateTime Created { get; set; }
    
    public int OrganizationId { get; set; }
    public OrganizationEntity? Organization { get; set; }
    
}