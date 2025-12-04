using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicalManagement.Domain.Entities
{
    public class Clinic :BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
