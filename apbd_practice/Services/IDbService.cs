using apbd_practice.DTOs;

namespace apbd_practice.Services;

public interface IDbService
{
    Task AddPrescription(PrescriptionDto prescription);
    Task<PatientDto> GetPatientData(int patientId);
}