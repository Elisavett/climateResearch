namespace climateResearch.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("measuring_instrument")]
    public partial class MeasuringInstrument : EntityBase
    {
        [StringLength(300)]
        [Column("description")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Column("observation_point_id")]
        public long? ObservationPointId { get; set; }

        [Display(Name = "Пункт наблюдения")]
        public virtual ObservationPoint ObservationPoint { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sensor> Sensors { get; set; } = new HashSet<Sensor>();
    }
}
