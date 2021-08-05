namespace climateResearch.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("observation_point")]
    public partial class ObservationPoint : EntityBase
    {
        [StringLength(300)]
        [Column("description")]
        [Display(Name = "��������")]
        public string Description { get; set; }

        [Column("latitude", TypeName = "numeric")]
        [Display(Name = "������")]
        public decimal Latitude { get; set; }

        [Column("longtitude", TypeName = "numeric")]
        [Display(Name = "�������")]
        public decimal Longtitude { get; set; }

        public virtual ICollection<MeasuringInstrument> MeasuringInstruments { get; set; } = new HashSet<MeasuringInstrument>();
    }
}
