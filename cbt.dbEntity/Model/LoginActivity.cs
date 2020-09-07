namespace cbt.dbEntity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoginActivity")]
    public partial class LoginActivity
    {
        public int LoginActivityId { get; set; }

        public int? UserId { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Gender { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public bool? IsEmailConfirmed { get; set; }

        [StringLength(50)]
        public string emailConfirmationCode { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public bool? IsFirstLoginAttempt { get; set; }

        public bool? IsLockoutEnabled { get; set; }

        public bool? IsLocked { get; set; }

        public int? FailedLoginAttempt { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? DeactivationDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public bool? IsLogout { get; set; }

        public DateTime? CreationDate { get; set; }
    }
}
