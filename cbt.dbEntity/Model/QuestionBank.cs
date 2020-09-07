namespace cbt.dbEntity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuestionBank")]
    public partial class QuestionBank
    {
        public int QuestionBankId { get; set; }

        public int QuestionTypeId { get; set; }

        [Required]
        public string Question { get; set; }

        public int TestCategoryId { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? DateOfCreation { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? DateOfDeletion { get; set; }

        [StringLength(50)]
        public string DeletedBy { get; set; }

        [StringLength(500)]
        public string OptionA { get; set; }

        [StringLength(500)]
        public string OptionB { get; set; }
    }
}
