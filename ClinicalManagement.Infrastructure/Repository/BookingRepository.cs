using ClinicalBookingSystem.Data;
using ClinicalManagement.Application.Interfaces;
using ClinicalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ClinicalManagement.Infrastructure.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ClinicalContextDB _ctx;
        public BookingRepository(ClinicalContextDB ctx) => _ctx = ctx;


        public async Task<List<Clinic>> GetClinicsAsync(CancellationToken ct = default) => await _ctx.clinics.AsNoTracking().ToListAsync(ct);


        public async Task<List<TimeSlot>> GetAvailableTimeSlotsAsync(Guid clinicId, DateTime date, CancellationToken ct = default)
        {
            var day = date.Date;
            return await _ctx.timeslots.Where(t => t.ClinicId == clinicId && t.StartTime.Date == day && !t.IsAvailable).OrderBy(t => t.StartTime).ToListAsync(ct);
        }


        public async Task<Appointment> CreateAppointmentAsync(Appointment appt, CancellationToken ct = default)
        {
            // Mark timeslot as booked
            var ts = await _ctx.timeslots.FindAsync(new object[] { appt.AppointmentDate }, ct);
            if (ts == null) throw new Exception("TimeSlot not found");
            if (ts.IsAvailable) throw new Exception("TimeSlot already booked");
            ts.IsAvailable = true;
            _ctx.appointments.Add(appt);
            await _ctx.SaveChangesAsync(ct);
            return appt;
        }

        Task<Patient> IBookingRepository.EnsurePatientAsync(Patient patient, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Appointment>> GetAllPatientsAsync()
        {
            return await _ctx.appointments.Where(e => !e.Status).ToListAsync();
        }
    }
}
