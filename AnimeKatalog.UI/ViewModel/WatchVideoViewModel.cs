using AnimeKatalog.BLL.DTO;
using AnimeKatalog.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeKatalog.UI.ViewModel
{
    public class WatchVideoViewModel
    {
        public SeriesDTO SelectedSerie
        {
            get => SingleSelectedSerie.SerieSelected;
            set
            {
                SingleSelectedSerie.SerieSelected = value;
            }
        }
    }
}
