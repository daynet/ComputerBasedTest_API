namespace cbt.dbEntity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuestionOption")]
    public partial class QuestionOption
    {
        [Key]
        public int QuetionOptionId { get; set; }

        public int? OptionTypeId { get; set; }

        public int? QuestionBankId { get; set; }

        public string QuetionOptionName { get; set; }

        [StringLength(50)]
        public string OptionLabel { get; set; }
    }
}
