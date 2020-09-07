namespace cbt.dbEntity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PublishedQuestion")]
    public partial class PublishedQuestion
    {
        public int PublishedQuestionId { get; set; }

        public int? QuestionBankId { get; set; }

        public int TestSetupId { get; set; }
    }
}
