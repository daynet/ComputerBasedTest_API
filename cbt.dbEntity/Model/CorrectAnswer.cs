namespace cbt.dbEntity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CorrectAnswer")]
    public partial class CorrectAnswer
    {
        public int CorrectAnswerId { get; set; }

        public int QuestionBankId { get; set; }

        public int QuestionOptionId { get; set; }

        public int QuestionOptionTypeId { get; set; }
    }
}
