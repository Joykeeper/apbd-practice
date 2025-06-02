using System.ComponentModel.DataAnnotations;

namespace apbd_practice.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; }
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }
    
    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    public virtual Patient Patient { get; set; }
    public virtual Doctor Doctor { get; set; }
}