using System.ComponentModel.DataAnnotations;

namespace apbd_practice.Models;

public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    [MaxLength(100)]
    public required string FirstName { get; set; }
    [MaxLength(100)]
    public required string LastName { get; set; }
    
    [DataType(DataType.Date)]
    public required DateTime Birthdate { get; set; }
    
    public virtual ICollection<Prescription> Prescriptions { get; set; }

}