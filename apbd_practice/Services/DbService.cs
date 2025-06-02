using apbd_practice.Data;
using apbd_practice.DTOs;
using apbd_practice.Exceptions;
using apbd_practice.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_practice.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task AddPrescription(PrescriptionDto prescription)
    {
        if (prescription.Medicaments.Count > 10)
        {
            throw new MedicamentOverflowException();
        }

        if (prescription.DueDate < prescription.Date)
        {
            throw new DueDateBeforeDateException();
        }
        
        var patient = await _context.Patients.FindAsync(prescription.IdPatient);

        if (patient == null)
        {
            throw new PatientNotFoundException();
        }

        foreach (var medicament in prescription.Medicaments)
        {
            var m = await _context.Medicaments.FindAsync(medicament.IdMedicament);
            if (m == null)
            {
                throw new MedicamentNotExistsException();
            }
        }

        var newPrescription = new Prescription
        {
            IdPatient = prescription.IdPatient,
            IdDoctor = prescription.IdDoctor,
            Date = prescription.Date,
            DueDate = prescription.DueDate,
            PrescriptionMedicaments = prescription.Medicaments.Select(m => new PrescriptionMedicament
            {
                IdMedicament = m.IdMedicament,
                Dose = m.Dose,
                Details = m.Description
            }).ToList()
        };
        
        await _context.Prescriptions.AddAsync(newPrescription);
        await _context.SaveChangesAsync();
    }

    public async Task<PatientDto> GetPatientData(int patientId)
    {
        var patient = await _context.Patients.FindAsync(patientId);
        Console.WriteLine($"Patient with id {patientId} not found");


        if (patient == null)
        {
            Console.WriteLine($"Patient with id {patientId} not found");
            throw new PatientNotFoundException();
        }

        var patientData = await _context.Patients
            .Where(p => p.IdPatient == patientId)
            .Select(p => new PatientDto
            {
                IdPatient = patient.IdPatient,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Birthdate = patient.Birthdate,
                Prescriptions = p.Prescriptions
                    .OrderBy(pr => pr.DueDate)
                    .Select(pr => new PatientPrescriptionDto
                    {
                        Doctor = new DoctorDto
                        {
                            IdDoctor = pr.Doctor.IdDoctor,
                            FirstName = pr.Doctor.FirstName
                        },
                        Date = pr.Date,
                        DueDate = pr.DueDate,
                        Medicaments = pr.PrescriptionMedicaments
                            .Select(m => new PatientMedicamentDto
                            {
                                IdMedicament = m.IdMedicament,
                                Name = m.Medicament.Name,
                                Dose = m.Dose,
                                Description = m.Medicament.Description
                            }).ToList()
                    }).ToList(),
            }).FirstAsync();
        
        return patientData;
    }
}