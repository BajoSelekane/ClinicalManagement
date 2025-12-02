using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicalManagement.Application.Features.Appointments.Queries
{
    public record GetAvailableTimeSlotsQuery(Guid ClinicId, DateTime Date) : IRequest<List<Domain.Entities.TimeSlot>>;
}
