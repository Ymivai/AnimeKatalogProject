using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeKatalog.BLL.DTO
{
    public class FullAnimeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int? Star { get; set; }
        public string Description { get; set; }
        public string ImgURL { get; set; }
        public string Year { get; set; }
        public int? AvtorID { get; set; }
        public string FavoriteAnime { get; set; }
        public ICollection<GanreDTO> GanresDTO { get; set; }
        public ICollection<SeriesDTO> SeriesDTO { get; set; }
        public ICollection<CharacterDTO> CharacterDTO { get; set; }
    }
}
