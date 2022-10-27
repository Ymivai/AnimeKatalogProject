namespace AnimeKatalog.DAL.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Anime")]
    public partial class Anime
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Anime()
        {
            Character = new HashSet<Character>();
            Series = new HashSet<Series>();
            Account = new HashSet<Account>();
            Ganre = new HashSet<Ganre>();
        }

        public int AnimeID { get; set; }

        [Required]
        [StringLength(200)]
        public string AnimeName { get; set; }

        public int? AnimeStar { get; set; }

        [StringLength(1000)]
        public string AnimeDescription { get; set; }

        [StringLength(3000)]
        public string AnimeImgURL { get; set; }

        [Required]
        [StringLength(10)]
        public string AnimeYear { get; set; }

        public int? Avtor { get; set; }

        public virtual Avtor Avtor1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Character> Character { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Series> Series { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ganre> Ganre { get; set; }
    }
}
