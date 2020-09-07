namespace cbt.dbEntity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nationality")]
    public partial class Nationality
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NationalityID { get; set; }

        public string NationalityName { get; set; }
    }
}
