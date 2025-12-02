using MediatR;


namespace ClinicalManagement.Application.Features.Appointments.Commands
{
    public record CreateAppointmentCommand(
        Guid ClinicId,
        DateTime AppoitmentDate,
        string Name,
        long? IdNumber,
        string? PhoneNumber,
        DateTime DOB,
        string Desc) : IRequest<Guid>;
}
