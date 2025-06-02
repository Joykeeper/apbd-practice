using System.ComponentModel.DataAnnotations;

namespace apbd_practice.Models;

public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }
    [MaxLength(100)]
    public required string FirstName { get; set; }
    [MaxLength(100)]
    public required string LastName { get; set; }
    [EmailAddress]
    public required string Email { get; set; }
    
    public virtual ICollection<Prescription> Prescriptions { get; set; }

}