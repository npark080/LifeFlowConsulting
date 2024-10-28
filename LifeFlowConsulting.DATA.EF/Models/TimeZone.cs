using System;
using System.Collections.Generic;

namespace LifeFlowConsulting.DATA.EF.Models
{
    public partial class TimeZone
    {
        public TimeZone()
        {
            Students = new HashSet<Student>();
        }

        public int TimeZoneId { get; set; }
        public string TimeZoneName { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
    }
}
