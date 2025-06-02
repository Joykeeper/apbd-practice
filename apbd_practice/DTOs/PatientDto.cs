using apbd_practice.Models;

namespace apbd_practice.DTOs;

public class PatientDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public List<PatientPrescriptionDto> Prescriptions { get; set; }
}

public class PatientPrescriptionDto
{
    public int IdPatient { get; set; }
    public DoctorDto Doctor { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public List<PatientMedicamentDto> Medicaments { get; set; }
}

public class DoctorDto
{
    public int IdDoctor { get; set; }
    public required string FirstName { get; set; }
}

public class PatientMedicamentDto
{
    public int IdMedicament { get; set; }
    public required string Name { get; set; }
    public int Dose { get; set; }
    public required string Description { get; set; }
}