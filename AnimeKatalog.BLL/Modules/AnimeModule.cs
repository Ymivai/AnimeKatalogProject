using AnimeKatalog.BLL.Services;
using AnimeKatalog.DAL.Context;
using AnimeKatalog.DAL.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeKatalog.BLL.Modules
{
    public class AnimeModule: NinjectModule
    {
        public override void Load()
        {
            //Repository
            Bind<AnimeRepository>().To<AnimeRepository>();
            Bind<AccountRepository>().To<AccountRepository>();
            Bind<AvtorRepository>().To<AvtorRepository>();
            Bind<CharacterRepository>().To<CharacterRepository>();
            Bind<GanreRepository>().To<GanreRepository>();
            Bind<SeriesRepository>().To<SeriesRepository>();
            //Service
            Bind<AccountService>().To<AccountService>();
            Bind<CharacterService>().To<CharacterService>();
            Bind<AnimeService>().To<AnimeService>();
            Bind<AvtorService>().To<AvtorService>();
            Bind<GanreService>().To<GanreService>();
            Bind<SeriesService>().To<SeriesService>();
            //Context
            Bind<DbContext>().To<AnimeKatalogContext>();
        }
    }
}
