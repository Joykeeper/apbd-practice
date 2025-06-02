using System.ComponentModel.DataAnnotations;

namespace apbd_practice.Models;

public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    [MaxLength(100)]
    public required string Name { get; set; }
    [MaxLength(100)]
    public required string Description { get; set; }
    [MaxLength(100)]
    public required string  Type { get; set; }
    
    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}