namespace climateResearch.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("observation_point")]
    public partial class ObservationPoint
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("name")]
        public string Name { get; set; }

        [StringLength(300)]
        [Column("description")]
        public string Description { get; set; }

        [Column("latitude", TypeName = "numeric")]
        public decimal Latitude { get; set; }

        [Column("longtitude", TypeName = "numeric")]
        public decimal Longtitude { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeasuringInstrument> MeasuringInstruments { get; set; } = new HashSet<MeasuringInstrument>();
    }
}
