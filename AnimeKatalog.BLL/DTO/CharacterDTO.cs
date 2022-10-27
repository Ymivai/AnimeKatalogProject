using AnimeKatalog.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeKatalog.BLL.DTO
{
    public class CharacterDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public int? AnimeID { get; set; }
    }
}
