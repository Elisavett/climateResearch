namespace climateResearch.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("physical_quantity")]
    public partial class PhysicalQuantity : EntityBase
    {
        [Required]
        [StringLength(10)]
        [Column("designation")]
        [Display(Name = "Обозначение")]
        public string Designation { get; set; }

        [Required]
        [StringLength(10)]
        [Column("unit")]
        [Display(Name = "Единица измерения")]
        public string Unit { get; set; }

        public virtual ICollection<Sensor> Sensors { get; set; } = new HashSet<Sensor>();
    }
}
