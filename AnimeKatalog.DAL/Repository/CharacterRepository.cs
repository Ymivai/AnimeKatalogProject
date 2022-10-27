using AnimeKatalog.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeKatalog.DAL.Repository
{
    public class CharacterRepository : BaseRepository<Character>
    {
        public CharacterRepository(DbContext context) : base(context)
        {
        }
    }
}
