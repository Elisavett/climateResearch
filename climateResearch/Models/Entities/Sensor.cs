namespace climateResearch.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sensor")]
    public partial class Sensor
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100), Column("name")]
        public string Name { get; set; }

        [StringLength(50), Column("measurement_mode")]
        public string MeasurementMode { get; set; }
        [Column("measuring_instrument_id")]
        public long? MeasuringInstrumentId { get; set; }
        [Column("physical_quantity_id")]
        public long? PhysicalQuantityId { get; set; }
        [Required]
        [StringLength(30)]
        [Column("designation")]
        public string Designation { get; set; }

        [Required]
        [StringLength(30)]
        [Column("db_name")]
        public string DbName { get; set; }

        [Required]
        [StringLength(30)]
        [Column("db_table")]
        public string DbTable { get; set; }
        public virtual MeasuringInstrument MeasuringInstrument { get; set; }
        public virtual PhysicalQuantity PhysicalQuantity { get; set; }
    }
}
