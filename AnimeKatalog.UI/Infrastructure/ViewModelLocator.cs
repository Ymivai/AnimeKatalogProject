using AnimeKatalog.BLL.Modules;
using AnimeKatalog.UI.ViewModel;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeKatalog.UI.Infrastructure
{
    public class ViewModelLocator
    {
        private IKernel _container;
        public ViewModelLocator()
        {
            _container = new StandardKernel(new AnimeModule());
        }
        public AnimeViewModel AnimeViewModel => _container.Get<AnimeViewModel>();
        public AdminViewModel AdminViewModel => _container.Get<AdminViewModel>();
        public InfoAnimeModel InfoAnimeModel => _container.Get<InfoAnimeModel>();
        public WatchVideoViewModel WatchVideoViewModel => _container.Get<WatchVideoViewModel>();
    }
}
