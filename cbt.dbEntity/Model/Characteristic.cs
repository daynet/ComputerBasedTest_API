namespace cbt.dbEntity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Characteristic")]
    public partial class Characteristic
    {
        public int CharacteristicId { get; set; }

        [StringLength(50)]
        public string Rating { get; set; }

        public string Quality { get; set; }

        [StringLength(50)]
        public string Key { get; set; }
    }
}
