namespace AnimeKatalog.DAL.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Avtor")]
    public partial class Avtor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Avtor()
        {
            Anime = new HashSet<Anime>();
        }

        public int AvtorID { get; set; }

        [Required]
        [StringLength(100)]
        public string AvtorName { get; set; }

        [Required]
        [StringLength(100)]
        public string AvtorFirstName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anime> Anime { get; set; }
    }
}
