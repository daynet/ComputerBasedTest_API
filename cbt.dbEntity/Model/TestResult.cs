namespace cbt.dbEntity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TestResult")]
    public partial class TestResult
    {
        public int TestResultId { get; set; }

        public int? Psid { get; set; }

        public int? QuestionBankId { get; set; }

        [StringLength(5)]
        public string Answer { get; set; }

        [StringLength(5)]
        public string Altanswer { get; set; }

        public int? TestCategoryId { get; set; }

        public DateTime? DateTaken { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? FinishTime { get; set; }
    }
}
