namespace AnimeKatalog.DAL.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Anime = new HashSet<Anime>();
        }

        public int AccountID { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountLogin { get; set; }

        [Required]
        [StringLength(100)]
        public string AccountPassword { get; set; }

        [Required]
        [StringLength(1000)]
        public string AccountImage { get; set; }

        public bool? AccountAdmin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anime> Anime { get; set; }
    }
}
