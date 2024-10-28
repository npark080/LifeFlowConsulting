using System;
using System.Collections.Generic;

namespace LifeFlowConsulting.DATA.EF.Models
{
    public partial class StudentStatus
    {
        public StudentStatus()
        {
            Students = new HashSet<Student>();
        }

        public int StudentStatusId { get; set; }
        public string StudentStatusName { get; set; } = null!;
        public string? StudentStatusDescription { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
