using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace climateResearch.Models.Entities
{
    public class EntityBase
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100), Column("name")]
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}