namespace cbt.dbEntity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserClaim")]
    public partial class UserClaim
    {
        [Key]
        public int UserClaimsId { get; set; }

        [StringLength(50)]
        public string ClaimType { get; set; }

        [StringLength(100)]
        public string ClaimValue { get; set; }

        public int? UserId { get; set; }
    }
}
