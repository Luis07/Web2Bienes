namespace Banco.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal id_post { get; set; }

        [Column(TypeName = "numeric")]
        public decimal id_image { get; set; }

        [Column(TypeName = "numeric")]
        public decimal id_comment { get; set; }

        [Required]
        [StringLength(250)]
        public string tittle { get; set; }

        [Required]
        [StringLength(250)]
        public string description { get; set; }

        [Required]
        [StringLength(250)]
        public string contenido { get; set; }

        public virtual Coment Coment { get; set; }

        public virtual Image Image { get; set; }
    }
}
