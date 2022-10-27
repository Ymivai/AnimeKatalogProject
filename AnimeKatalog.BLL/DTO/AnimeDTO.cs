using AnimeKatalog.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeKatalog.BLL.DTO
{
    public class AnimeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int? Star { get; set; }
        public string Description { get; set; }
        public string ImgURL { get; set; }
        public string Year { get; set; }
        public int? AvtorID { get; set; }
    }
}
