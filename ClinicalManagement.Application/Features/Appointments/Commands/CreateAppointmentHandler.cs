using ClinicalManagement.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicalManagement.Application.Features.Appointments.Commands
{
    public class CreateAppointmentHandler : IRequestHandler<CreateAppointmentCommand, string>
    {
        private readonly IBookingRepository _repo;
        public CreateAppointmentHandler(IBookingRepository repo) => _repo = repo;


        public async Task<string> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            // Basic validation
            var patient = new Domain.Entities.Patient
            {
               // Id = Guid.NewGuid(),
                Name = request.Name,
                IDNumber = request.IdNumber,
                PhoneNumber = request.PhoneNumber,
                DateOfBirth = request.DOB,
                Description = request.Desc
            };
            var savedPatient = await _repo.EnsurePatientAsync(patient, cancellationToken);


            var appointment = new Domain.Entities.Appointment
            {
               // Id = Guid.NewGuid(),
                ClinicId = request.ClinicId,
                PatientId = savedPatient.Id,
                AppointmentDate =request.AppoitmentDate,
                CreatedAt = DateTime.UtcNow
                //Status = true
                //TimeSlotId = request.TimeSlotId,
            };

            var created = await _repo.CreateAppointmentAsync(appointment, cancellationToken);          
            return created.Id;
        }
    }
}
    
