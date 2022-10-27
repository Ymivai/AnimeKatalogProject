using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeKatalog.BLL.DTO
{
    public class SeriesDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int? Number { get; set; }
        public string URL { get; set; }

        public int? AnimeID { get; set; }
    }
}
