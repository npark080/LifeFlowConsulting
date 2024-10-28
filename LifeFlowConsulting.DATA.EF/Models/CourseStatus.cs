using System;
using System.Collections.Generic;

namespace LifeFlowConsulting.DATA.EF.Models
{
    public partial class CourseStatus
    {
        public CourseStatus()
        {
            Courses = new HashSet<Course>();
        }

        public int CourseStatusId { get; set; }
        public string CourseStatusName { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
    }
}
