using AnimeKatalog.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeKatalog.DAL.Repository
{
    public class AvtorRepository : BaseRepository<Avtor>
    {
        public AvtorRepository(DbContext context) : base(context)
        {
        }
    }
}
