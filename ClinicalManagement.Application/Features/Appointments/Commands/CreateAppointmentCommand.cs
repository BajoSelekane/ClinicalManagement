using MediatR;


namespace ClinicalManagement.Application.Features.Appointments.Commands
{
    public record CreateAppointmentCommand(
        string ClinicId,
        DateTime AppoitmentDate,
        string Name,
        string? IdNumber,
        string? PhoneNumber,
        DateTime DOB,
        string Desc) : IRequest<string>;
}
