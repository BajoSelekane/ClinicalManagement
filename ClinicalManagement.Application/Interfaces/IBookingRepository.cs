using ClinicalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicalManagement.Application.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Appointment>> GetAllPatientsAsync();
        Task<List<Clinic>> GetClinicsAsync(CancellationToken ct = default);
        Task<List<TimeSlot>> GetAvailableTimeSlotsAsync(Guid clinicId, DateTime date, CancellationToken ct = default);
        Task<Appointment> CreateAppointmentAsync(Appointment appt, CancellationToken ct = default);
        Task<Patient> EnsurePatientAsync(Patient patient, CancellationToken ct = default);
    }
}
