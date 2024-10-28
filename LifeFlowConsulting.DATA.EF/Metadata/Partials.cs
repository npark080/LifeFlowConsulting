using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LifeFlowConsulting.DATA.EF.Models.Metadata;

namespace LifeFlowConsulting.DATA.EF.Models//.Metadata
{

    [ModelMetadataType(typeof(CourseMetadata))]
    public partial class Course { }


    [ModelMetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollment { }


    [ModelMetadataType(typeof(CourseStatusMetadata))]
    [Display(Name = "Course Status")]
    public partial class CourseStatus { }


    [ModelMetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
        [NotMapped]
        [Display(Name = "Full Name")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public string FullName => $"{FirstName} {LastName}";
    }


    [ModelMetadataType(typeof(StudentStatusMetadata))]
    [Display(Name = "Student Status")]
    public partial class StudentStatus { }


    [ModelMetadataType(typeof(TimeZoneMetadata))]
    [Display(Name = "Time Zone")]
    public partial class TimeZone { }

}


