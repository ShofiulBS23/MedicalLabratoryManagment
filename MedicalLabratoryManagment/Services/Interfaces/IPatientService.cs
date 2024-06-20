using MedicalLabratoryManagment.Models;

namespace MedicalLabratoryManagment.Services.Interfaces;

public interface IPatientService
{
    Task AddPatientAsync(Patient patient);
    Task UpdatePatientAsync(Patient patient);
    Task DeletePatientAsync(int patientId);
    Task<Patient> SearchPatientAsync(int patientId);
    Task<IEnumerable<Patient>> GetAllPatientsAsync();
}

