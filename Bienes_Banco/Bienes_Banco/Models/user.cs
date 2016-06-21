namespace Bienes_Banco.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        public int id { get; set; }

        [Required]
        [StringLength(250)]
        public string name { get; set; }

        [Required]
        [StringLength(250)]
        public string lastname { get; set; }

        public bool admin { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(250)]
        public string ubicacion { get; set; }

        public bool activo { get; set; }

        public bool bloqueado { get; set; }

        public string asunto { get; set; }
        
        public string contenido { get; set; }
    }
}
