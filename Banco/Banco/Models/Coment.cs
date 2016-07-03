namespace Banco.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Coment")]
    public partial class Coment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Coment()
        {
            Post = new HashSet<Post>();
        }

        [Column(TypeName = "numeric")]
        public decimal id { get; set; }

        [StringLength(250)]
        public string usuario { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? id_image { get; set; }

        [StringLength(250)]
        public string comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Post { get; set; }

        public virtual Image Image { get; set; }
    }
}
