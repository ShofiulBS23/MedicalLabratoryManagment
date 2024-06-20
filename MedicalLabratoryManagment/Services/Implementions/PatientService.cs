using MedicalLabratoryManagment.Data;
using MedicalLabratoryManagment.Models;
using MedicalLabratoryManagment.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalLabratoryManagment.Services.Implementations;

public class PatientService : IPatientService
{
    private readonly ApplicationDbContext _context;

    public PatientService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddPatientAsync(Patient patient)
    {
        try {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        } catch (Exception ex) {
            throw new Exception("Failed to add patient", ex);
        }
    }

    public async Task UpdatePatientAsync(Patient patient)
    {
        try {
            var existingPatient = await _context.Patients.FindAsync(patient.PatientID);
            if (existingPatient != null) {
                _context.Entry(existingPatient).CurrentValues.SetValues(patient);
                await _context.SaveChangesAsync();
            }
        } catch (Exception ex) {
            throw new Exception("Failed to update patient", ex);
        }
    }

    public async Task DeletePatientAsync(int patientId)
    {
        try {
            var patient = await _context.Patients.FindAsync(patientId);
            if (patient != null) {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        } catch (Exception ex) {
            throw new Exception("Failed to delete patient", ex);
        }
    }

    public async Task<Patient> SearchPatientAsync(int patientId)
    {
        try {
            return await _context.Patients.FindAsync(patientId);
        } catch (Exception ex) {
            throw new Exception("Failed to find patient", ex);
        }
    }

    public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
    {
        return await _context.Patients.ToListAsync();
    }
}
