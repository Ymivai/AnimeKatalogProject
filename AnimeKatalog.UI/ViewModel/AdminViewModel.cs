using AnimeKatalog.BLL.DTO;
using AnimeKatalog.BLL.Services;
using AnimeKatalog.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace AnimeKatalog.UI.ViewModel
{
    public class AdminViewModel : BaseNotify
    {
        #region Services
        private AnimeService _animeService;
        private AccountService _accountService;
        private AvtorService _avtorService;
        private CharacterService _characterService;
        private GanreService _ganreService;
        private SeriesService _seriesService;
        #endregion


        public AdminViewModel(AnimeService animeService, AccountService accountService, AvtorService avtorService,
                              CharacterService characterService, GanreService ganreService, SeriesService seriesService)
        {
            _animeService = animeService;
            _accountService = accountService;
            _avtorService = avtorService;
            _characterService = characterService;
            _ganreService = ganreService;
            _seriesService = seriesService;

            LoadAnimes();
        }

        #region Command

        #region RemoveCommand
        private RelayCommand _removeAccountCommand;
        private RelayCommand _removeAnimeCommand;
        private RelayCommand _removeAvtorCommand;
        private RelayCommand _removeCharacterCommand;
        private RelayCommand _removeGanreCommand;
        private RelayCommand _removeSeriesCommand;


        public RelayCommand RemoveAccountCommand
        {
            get
            {
                if (_removeAccountCommand == null)
                    _removeAccountCommand = new RelayCommand(x =>
                    {
                        _accountService.Remove(SelectAccount);
                        Accounts.Remove(SelectAccount);
                    });
                return _removeAccountCommand;
            }
        }
        public RelayCommand RemoveAnimeCommand
        {
            get
            {
                if (_removeAnimeCommand == null)
                    _removeAnimeCommand = new RelayCommand(x =>
                    {
                        _animeService.Remove(SelectAnime);
                        Animes.Remove(SelectAnime);
                    });
                return _removeAnimeCommand;
            }
        }
        public RelayCommand RemoveAvtorCommand
        {
            get
            {
                if (_removeAvtorCommand == null)
                    _removeAvtorCommand = new RelayCommand(x =>
                    {
                        _avtorService.Remove(SelectAvtor);
                        Avtors.Remove(SelectAvtor);
                    });
                return _removeAvtorCommand;
            }
        }
        public RelayCommand RemoveCharacterCommand
        {
            get
            {
                if (_removeCharacterCommand == null)
                    _removeCharacterCommand = new RelayCommand(x =>
                    {
                        _characterService.Remove(SelectCharacter);
                        Characters.Remove(SelectCharacter);
                    });
                return _removeCharacterCommand;
            }
        }
        public RelayCommand RemoveGanreCommand
        {
            get
            {
                if (_removeGanreCommand == null)
                    _removeGanreCommand = new RelayCommand(x =>
                    {
                        _ganreService.Remove(SelectGanre);
                        Ganres.Remove(SelectGanre);
                    });
                return _removeGanreCommand;
            }
        }
        public RelayCommand RemoveSeriesCommand
        {
            get
            {
                if (_removeSeriesCommand == null)
                    _removeSeriesCommand = new RelayCommand(x =>
                    {
                        _seriesService.Remove(SelectSeries);
                        Series.Remove(SelectSeries);
                    });
                return _removeSeriesCommand;
            }
        }
        #endregion
        #region AddCommand
        private RelayCommand _addAccountCommand;
        private RelayCommand _addAnimeCommand;
        private RelayCommand _addAvtorCommand;
        private RelayCommand _addCharacterCommand;
        private RelayCommand _addGanreCommand;
        private RelayCommand _addSerieCommand;


        public ICommand AddAcoountCommand
        {
            get
            {
                if (_addAccountCommand == null)
                    _addAccountCommand = new RelayCommand(x =>
                    {
                        var anime = _accountService.Add(new AccountDTO
                        {
                            Login = "login",
                            Password = "0000",
                            Image = "https://i.imgur.com/Cme6xaG.jpg",
                            Admin = false
                        });
                        Accounts.Add(anime);
                    });
                return _addAccountCommand;
            }
        }
        public ICommand AddAnimeCommand
        {
            get
            {
                if (_addAnimeCommand == null)
                    _addAnimeCommand = new RelayCommand(x =>
                    {
                        var anime = _animeService.Add(new AnimeDTO
                        {
                            Name = "Null",
                            ImgURL = "https://helpmyos.ru/wp-content/uploads/2016/04/Oshibka-kernel-data-inpage-error-izbavlyaemsya-ot-sinego-ekrana.png",
                            Star = 0,
                            Year = "Null",
                            Description = "Null",
                            AvtorID = null
                        });
                        Animes.Add(anime);
                    });
                return _addAnimeCommand;
            }
        }
        public ICommand AddAvtorCommand
        {
            get
            {
                if (_addAvtorCommand == null)
                    _addAvtorCommand = new RelayCommand(x =>
                    {
                        var anime = _avtorService.Add(new AvtorDTO
                        {
                            Name = "Null",
                            FirstName = "Null"
                        });
                        Avtors.Add(anime);
                        AvtorsName = _avtorService.GetAll().Select(avtor => avtor.FirstName).ToList();
                    });
                return _addAvtorCommand;
            }
        }
        public ICommand AddCharacterCommand
        {
            get
            {
                if (_addCharacterCommand == null)
                    _addCharacterCommand = new RelayCommand(x =>
                    {
                        var anime = _characterService.Add(new CharacterDTO
                        {
                            Name = "name",
                            FirstName = "firstname",
                            AnimeID = null
                        });
                        Characters.Add(anime);
                    });
                return _addCharacterCommand;
            }
        }
        public ICommand AddGanreCommand
        {
            get
            {
                if (_addGanreCommand == null)
                    _addGanreCommand = new RelayCommand(x =>
                    {
                        var anime = _ganreService.Add(new GanreDTO
                        {
                            Name = "null"
                        });
                        Ganres.Add(anime);
                    });
                return _addGanreCommand;
            }
        }
        public ICommand AddSerieCommand
        {
            get
            {
                if (_addSerieCommand == null)
                    _addSerieCommand = new RelayCommand(x =>
                    {
                        var anime = _seriesService.Add(new SeriesDTO
                        {
                            Name = "Null",
                            Number = null,
                            AnimeID = null
                        });
                        Series.Add(anime);
                    });
                return _addSerieCommand;
            }
        }
        #endregion
        #region UppdateCommand
        private RelayCommand _uppdateAccountCommand;
        private RelayCommand _uppdateAnimeCommand;
        private RelayCommand _uppdateAvtorCommand;
        private RelayCommand _uppdateCharacterCommand;
        private RelayCommand _uppdateGanreCommand;
        private RelayCommand _uppdateSeriesCommand;


        public RelayCommand UppdateAccountCommand
        {
            get
            {
                if (_uppdateAccountCommand == null)
                    _uppdateAccountCommand = new RelayCommand(x =>
                    {
                        _accountService.Uppdate(SelectAccount);
                    });
                return _uppdateAccountCommand;
            }
        }
        public RelayCommand UppdateAnimeCommand
        {
            get
            {
                if (_uppdateAnimeCommand == null)
                    _uppdateAnimeCommand = new RelayCommand(x =>
                    {
                        var avtor = _avtorService.GetAll().FirstOrDefault(y => y.FirstName == _avtor);
                        SelectAnime.AvtorID = avtor?.ID;
                        _animeService.Uppdate(SelectAnime);
                        AnimesNameUppdate();
                    });
                return _uppdateAnimeCommand;
            }
        }
        public RelayCommand UppdateAvtorCommand
        {
            get
            {
                if (_uppdateAvtorCommand == null)
                    _uppdateAvtorCommand = new RelayCommand(x =>
                    {
                        _avtorService.Uppdate(SelectAvtor);
                        AvtorsNameUppdate();
                    });
                return _uppdateAvtorCommand;
            }
        }
        public RelayCommand UppdateCharacterCommand
        {
            get
            {
                if (_uppdateCharacterCommand == null)
                    _uppdateCharacterCommand = new RelayCommand(x =>
                    {
                        var anime = _animeService.GetAll().FirstOrDefault(y => y.Name == _anime);
                        SelectCharacter.AnimeID = anime?.ID;
                        _characterService.Uppdate(SelectCharacter);
                        
                    });
                return _uppdateCharacterCommand;
            }
        }
        public RelayCommand UppdateGanreCommand
        {
            get
            {
                if (_uppdateGanreCommand == null)
                    _uppdateGanreCommand = new RelayCommand(x =>
                    {
                        _ganreService.Uppdate(SelectGanre);
                    });
                return _uppdateGanreCommand;
            }
        }
        public RelayCommand UppdateSeriesCommand
        {
            get
            {
                if (_uppdateSeriesCommand == null)
                    _uppdateSeriesCommand = new RelayCommand(x =>
                    {
                        var anime = _animeService.GetAll().FirstOrDefault(y => y.Name == _anime);
                        SelectSeries.AnimeID = anime?.ID;
                        _seriesService.Uppdate(SelectSeries);
                    });
                return _uppdateSeriesCommand;
            }
        }
        #endregion

        #endregion

        #region Property
        private string _avtor;
        private List<string> _avtorsFirstName;
        private string _anime;
        private List<string> _animesName;


        public string Avtor
        {
            get => _avtor;
            set
            {
                _avtor = value;
                Notify();
            }
        }
        public List<string> AvtorsName
        {
            get => _avtorsFirstName;
            set
            {
                _avtorsFirstName = value;
                Notify();
            }
        }
        public string Anime
        {
            get => _anime;
            set
            {
                _anime = value;
                Notify();
            }
        }
        public List<string> AnimesName
        {
            get => _animesName;
            set
            {
                _animesName = value;
                Notify();
            }
        }
        #endregion
        #region Load
        private async void LoadAnimes()
        {
            var animes = await _animeService.GetAllAsync();
            Animes = new ObservableCollection<AnimeDTO>(animes);

            var accounts = await _accountService.GetAllAsync();
            Accounts = new ObservableCollection<AccountDTO>(accounts);

            var avtors = await _avtorService.GetAllAsync();
            Avtors = new ObservableCollection<AvtorDTO>(avtors);

            var characters = await _characterService.GetAllAsync();
            Characters = new ObservableCollection<CharacterDTO>(characters);

            var ganres = await _ganreService.GetAllAsync();
            Ganres = new ObservableCollection<GanreDTO>(ganres);

            var series = await _seriesService.GetAllAsync();
            Series = new ObservableCollection<SeriesDTO>(series);

            AvtorsNameUppdate();
            AnimesNameUppdate();
        }
        #endregion
        #region PropertyObservable<DTO>
        private ObservableCollection<AnimeDTO> _animes;
        private ObservableCollection<AccountDTO> _accounts;
        private ObservableCollection<CharacterDTO> _characters;
        private ObservableCollection<GanreDTO> _ganre;
        private ObservableCollection<SeriesDTO> _series;
        private ObservableCollection<AvtorDTO> _avtors;


        public ObservableCollection<AnimeDTO> Animes
        {
            get => _animes;
            set
            {
                _animes = value;
                Notify();
            }
        }

        public ObservableCollection<AccountDTO> Accounts
        {
            get => _accounts;
            set
            {
                _accounts = value;
                Notify();
            }
        }

        public ObservableCollection<AvtorDTO> Avtors
        {
            get => _avtors;
            set
            {
                _avtors = value;
                Notify();
            }
        }

        public ObservableCollection<CharacterDTO> Characters
        {
            get => _characters;
            set
            {
                _characters = value;
                Notify();
            }
        }

        public ObservableCollection<GanreDTO> Ganres
        {
            get => _ganre;
            set
            {
                _ganre = value;
                Notify();
            }
        }

        public ObservableCollection<SeriesDTO> Series
        {
            get => _series;
            set
            {
                _series = value;
                Notify();
            }
        }
        #endregion
        #region PropertyDTO
        private AnimeDTO _selectAnime;
        private AccountDTO _selectAccount;
        private CharacterDTO _selectCharacter;
        private GanreDTO _selectGanre;
        private SeriesDTO _selectSeries;
        private AvtorDTO _selectAvtor;


        public AnimeDTO SelectAnime
        {
            get => _selectAnime;
            set
            {
                _selectAnime = value;
                Avtor = _avtorService.GetAll().FirstOrDefault(y => y.ID == SelectAnime.AvtorID)?.FirstName;
                Notify();
            }
        }

        public AccountDTO SelectAccount
        {
            get => _selectAccount;
            set
            {
                _selectAccount = value;
                Notify();
            }
        }

        public CharacterDTO SelectCharacter
        {
            get => _selectCharacter;
            set
            {
                _selectCharacter = value;
                Anime = _animeService.GetAll().FirstOrDefault(y => y.ID == SelectCharacter.AnimeID)?.Name;
                Notify();
            }
        }

        public GanreDTO SelectGanre
        {
            get => _selectGanre;
            set
            {
                _selectGanre = value;
                Notify();
            }
        }

        public SeriesDTO SelectSeries
        {
            get => _selectSeries;
            set
            {
                _selectSeries = value;
                Notify();
            }
        }

        public AvtorDTO SelectAvtor
        {
            get => _selectAvtor;
            set
            {
                _selectAvtor = value;
                Notify();
            }
        }
        #endregion
        #region Methods
        private void AvtorsNameUppdate()
        {
            AvtorsName = _avtorService.GetAll().Select(x => x.FirstName).ToList();
        }
        private void AnimesNameUppdate()
        {
            AnimesName = _animeService.GetAll().Select(x => x.Name).ToList();
        }
        #endregion
    }
}
