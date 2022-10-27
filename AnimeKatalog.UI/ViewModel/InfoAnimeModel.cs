using AnimeKatalog.BLL.DTO;
using AnimeKatalog.BLL.Services;
using AnimeKatalog.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeKatalog.UI.ViewModel
{
    public class InfoAnimeModel
    {
        private AvtorService _avtorService;
        private string _avtor;
        private string _ganres;
        private string _actors;

        public InfoAnimeModel(AvtorService avtorService)
        {
            _avtorService = avtorService;

            Load();
        }

        public FullAnimeDTO SelectedAnime
        {
            get => SingleSelected.AnimeSelected;
            set
            {
                SingleSelected.AnimeSelected = value;
            }
        }

        public string Avtor
        {
            get => _avtor;
            set
            {
                _avtor = value;
            }
        }

        public string Ganres
        {
            get => _ganres;
            set
            {
                _ganres = value;
            }
        }

        public string Actors
        {
            get => _actors;
            set
            {
                _actors = value;
            }
        }
        private void Load()
        {
            var avtor = _avtorService.GetAll().FirstOrDefault(x => x.ID == SingleSelected.AnimeSelected.AvtorID);
            Avtor = $"{avtor.Name} {avtor.FirstName}";

            string tmp = "";
            foreach (var item in SelectedAnime.GanresDTO)
            {
                tmp += item.Name + ", ";
            }
            Ganres = tmp;

            tmp = "";
            foreach (var item in SelectedAnime.CharacterDTO)
            {
                tmp += $"{item.Name} {item.FirstName}, ";
            }
            Actors = tmp;
        }
    }
}
