namespace Bienes_Banco.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bien")]
    public partial class bien
    {
        [Key]
        public int id_bien { get; set; }

        [Required]
        [StringLength(250)]
        public string localizacion { get; set; }

        public int precio { get; set; }

        public int? recamaras { get; set; }

        public int? baños { get; set; }

        public int? estacionamientos { get; set; }

        public int? m_construccion { get; set; }

        [Required]
        public byte[] imagen { get; set; }

        public int? likes { get; set; }
    }
}
