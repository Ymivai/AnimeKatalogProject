namespace AnimeKatalog.DAL.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Character")]
    public partial class Character
    {
        public int CharacterID { get; set; }

        [Required]
        [StringLength(255)]
        public string CharacterName { get; set; }

        [Required]
        [StringLength(255)]
        public string CharacterFirstName { get; set; }

        public int? AnimeID { get; set; }

        public virtual Anime Anime { get; set; }
    }
}
