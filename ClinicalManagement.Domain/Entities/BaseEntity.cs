using ClinicalManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicalManagement.Domain.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public  string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public EntityStatus Status { get; set; }

    }
}
