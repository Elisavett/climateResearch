namespace climateResearch.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("measuring_instrument")]
    public partial class MeasuringInstrument
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("name")]
        public string Name { get; set; }

        [StringLength(300)]
        [Column("description")]
        public string Description { get; set; }

        [Column("observation_point_id")]
        public long? ObservationPointId { get; set; }

        public virtual ObservationPoint ObservationPoint { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sensor> Sensors { get; set; } = new HashSet<Sensor>();
    }
}
