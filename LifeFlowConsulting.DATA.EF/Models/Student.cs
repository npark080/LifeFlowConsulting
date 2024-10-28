using System;
using System.Collections.Generic;

namespace LifeFlowConsulting.DATA.EF.Models
{
    public partial class Student
    {
        public Student()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? City { get; set; }
        public string? State { get; set; }
        public int? TimeZoneId { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; } = null!;
        public string? SessionNotes { get; set; }
        public string? Notes { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Onboarding { get; set; }
        public DateTime? GoalsConvo { get; set; }
        public int StudentStatusId { get; set; }

        public virtual StudentStatus StudentStatus { get; set; } = null!;
        public virtual TimeZone? TimeZone { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
