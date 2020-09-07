namespace cbt.dbEntity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OptionType")]
    public partial class OptionType
    {
        public int OptionTypeId { get; set; }

        [StringLength(50)]
        public string OptionTypeName { get; set; }
    }
}
