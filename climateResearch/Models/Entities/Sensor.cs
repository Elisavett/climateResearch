namespace climateResearch.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sensor")]
    public partial class Sensor : EntityBase
    {

        [StringLength(50), Column("measurement_mode")]
        [Display(Name = "Режим измерения ")]
        public string MeasurementMode { get; set; }

        [Required]
        [StringLength(30)]
        [Column("designation")]
        [Display(Name = "Обозначение в базе данных")]
        public string Designation { get; set; }

        [Required]
        [StringLength(30)]
        [Column("db_name")]
        [Display(Name = "Название базы данных")]
        public string DbName { get; set; }

        [Required]
        [StringLength(30)]
        [Column("db_table")]
        [Display(Name = "Название таблицы базы данных")]
        public string DbTable { get; set; }

        [Column("measuring_instrument_id")]
        public long? MeasuringInstrumentId { get; set; }

        [Column("physical_quantity_id")]
        public long? PhysicalQuantityId { get; set; }
        public virtual MeasuringInstrument MeasuringInstrument { get; set; }
        public virtual PhysicalQuantity PhysicalQuantity { get; set; }
    }
}
