namespace climateResearch.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("physical_quantity")]
    public partial class PhysicalQuantity
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        [Column("designation")]
        public string Designation { get; set; }

        [Required]
        [StringLength(10)]
        [Column("unit")]
        public string Unit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sensor> Sensors { get; set; } = new HashSet<Sensor>();
    }
}
