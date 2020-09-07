namespace cbt.dbEntity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TestCategory")]
    public partial class TestCategory
    {
        public int TestCategoryId { get; set; }

        [StringLength(200)]
        public string CategoryName { get; set; }

        public DateTime? DateCreated { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public bool? IsDelete { get; set; }

        public DateTime? DateOfDeletion { get; set; }

        [StringLength(50)]
        public string DeletedBy { get; set; }
    }
}
