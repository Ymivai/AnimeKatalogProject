namespace AnimeKatalog.DAL.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Series
    {
        public int SeriesID { get; set; }

        [Required]
        [StringLength(200)]
        public string SeriesName { get; set; }

        public int? SeriesNumber { get; set; }

        [StringLength(1000)]
        public string SeriesURL { get; set; }

        public int? AnimeID { get; set; }

        public virtual Anime Anime { get; set; }
    }
}
