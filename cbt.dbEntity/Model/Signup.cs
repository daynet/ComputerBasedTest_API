namespace cbt.dbEntity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Signup")]
    public partial class Signup
    {
        [Key]
        public int Psid { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string MobileNo { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        public int? Program { get; set; }

        public string Address { get; set; }

        [StringLength(50)]
        public string COR { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Designation { get; set; }

        [StringLength(500)]
        public string NOI { get; set; }

        [StringLength(50)]
        public string Token { get; set; }

        public DateTime TokenExpirationDate { get; set; }

        [StringLength(50)]
        public string ExamDate { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public bool isCounsel { get; set; }

        public int? SchoolID { get; set; }

        public bool isContact { get; set; }

        [StringLength(50)]
        public string Levels { get; set; }
    }
}
