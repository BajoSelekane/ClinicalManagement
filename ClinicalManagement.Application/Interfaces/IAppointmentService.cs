using ClinicalManagement.Application.DTOs;
using ClinicalManagement.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicalManagement.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<ServiceResult> CreateAppointmentAsync(AppointmentViewModel model);
        Task<List<AppointmentDto>> GetAppointmentsAsync();
        Task<List<TimeSlotDto>> GetAvailableTimeSlotsAsync(string doctorId, DateTime date);
        Task DeleteAppointmentAsync(string id);
    }

   

    public class ServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
