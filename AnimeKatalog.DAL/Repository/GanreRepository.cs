using AnimeKatalog.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeKatalog.DAL.Repository
{
    public class GanreRepository : BaseRepository<Ganre>
    {
        public GanreRepository(DbContext context) : base(context)
        {
        }
    }
}
