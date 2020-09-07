namespace cbt.dbEntity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("State")]
    public partial class State
    {
        [StringLength(450)]
        public string Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string CreatedUser { get; set; }

        public string Name { get; set; }
    }
}
