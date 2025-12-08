using ClinicalManagement.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicalManagement.Application.Features.Appointments.Queries
{
    public class GetAvailableTimeSlotsHandler : IRequestHandler<GetAvailableTimeSlotsQuery, List<Domain.Entities.TimeSlot>>
    {
        private readonly IBookingRepository _repo;
        public GetAvailableTimeSlotsHandler(IBookingRepository repo) => _repo = repo;
        public Task<List<Domain.Entities.TimeSlot>> Handle(GetAvailableTimeSlotsQuery request, CancellationToken cancellationToken)
        => _repo.GetAvailableTimeSlotsAsync(request.ClinicId, request.Date, cancellationToken);
    }
}
