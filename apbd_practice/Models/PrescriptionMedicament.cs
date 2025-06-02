using System.ComponentModel.DataAnnotations;

namespace apbd_practice.Models;

public class PrescriptionMedicament
{
    public int IdMedicament { get; set; }
    public int IdPrescription { get; set; }
    public int Dose { get; set; }
    [MaxLength(100)]
    public required string Details { get; set; }
    
    public virtual Prescription Prescription { get; set; }
    public virtual Medicament Medicament { get; set; }
}