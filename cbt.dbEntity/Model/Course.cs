namespace cbt.dbEntity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        [StringLength(50)]
        public string SchoolCode { get; set; }

        

    }
}
