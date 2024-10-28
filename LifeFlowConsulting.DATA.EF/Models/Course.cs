using System;
using System.Collections.Generic;

namespace LifeFlowConsulting.DATA.EF.Models
{
    public partial class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string? CourseDescription { get; set; }
        public int CourseStatusId { get; set; }

        public virtual CourseStatus CourseStatus { get; set; } = null!;
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
