using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicalManagement.Domain.Entities
{
    public class Clinic
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
