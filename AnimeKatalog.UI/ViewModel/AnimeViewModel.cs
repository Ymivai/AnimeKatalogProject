using AnimeKatalog.BLL.DTO;
using AnimeKatalog.BLL.Services;
using AnimeKatalog.UI.Infrastructure;
using AnimeKatalog.UI.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace AnimeKatalog.UI.ViewModel
{
    public class AnimeViewModel : BaseNotify
    {
        #region Services
        private FullAnimeService _animeService;
        private AccountService _accountService;
        private AvtorService _avtorService;
        private SeriesService _seriesService;

        private ObservableCollection<FullAnimeDTO> _animes;
        private ObservableCollection<AccountDTO> _accounts;
        private ObservableCollection<SeriesDTO> _series;
        private ObservableCollection<AvtorDTO> _avtors;

        private FullAnimeDTO _selectAnime;
        private AccountDTO _selectAccount;
        private SeriesDTO _selectSeries;
        #endregion


        private string _searchFilter;
        private string _languge = "EU";
        private string _login;
        private string _password;
        private string _visibilityAdminPanel = "Hidden";
        private string _visibilityAccout = "Hidden";
        private string _visibilityError = "Hidden";
        private string _Error = "Login or password not right";
        public AnimeViewModel(FullAnimeService animeService, AccountService accountService,
                            AvtorService avtorService, SeriesService seriesService)
        {
            _animeService = animeService;
            _accountService = accountService;
            _avtorService = avtorService;
            _seriesService = seriesService;

            LoadAnimes();
        }


        #region Property
        public ICollectionView FilterCommand { get; set; }
        public string SearchAnime
        {
            get => _searchFilter;
            set
            {
                _searchFilter = value;
                Notify(nameof(SearchAnime));
                FilterCommand.Refresh();
            }
        }

        #region PropertyDTO
        public ObservableCollection<FullAnimeDTO> Animes
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

        #region SelectProperty
        public FullAnimeDTO SelectedAnime
        {
            get => _selectAnime;
            set
            {
                _selectAnime = value;
                SingleSelected.AnimeSelected = value;
                Notify();
            }
        }
        public SeriesDTO SelectedSerie
        {
            get => _selectSeries;
            set
            {
                _selectSeries = value;
                SingleSelectedSerie.SerieSelected = value;
                Notify();
            }
        }
        public AccountDTO SelectedAccount
        {
            get => _selectAccount;
            set
            {
                _selectAccount = value;
                Notify();
            }
        }
        #endregion

        #region StringProperty
        public string VisibilityError
        {
            get => _visibilityError;
            set
            {
                _visibilityError = value;
                Notify();
            }
        }

        public string Error
        {
            get => _Error;
        }

        public string VisibilityAccount
        {
            get => _visibilityAccout;
            set
            {
                _visibilityAccout = value;
                Notify();
            }
        }

        public string VisibilityAdminPanel
        {
            get => _visibilityAdminPanel;
            set
            {
                _visibilityAdminPanel = value;
                Notify();
            }
        }

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                Notify();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                Notify();
            }
        }
        #endregion
        #endregion
        #region Command
        private RelayCommand _updateList;
        private RelayCommand _expand;
        private RelayCommand _sortCommand;
        private RelayCommand _openCommand;
        private RelayCommand _viewCommand;
        private RelayCommand _authorithation;
        private RelayCommand _logOut;


        public ICommand Authorithation
        {
            get
            {
                if (_authorithation == null)
                    _authorithation = new RelayCommand(x =>
                    {
                        var account = Accounts.FirstOrDefault(y => y.Login == Login);
                        if (account != null && account.Password == Password)
                        {
                            SelectedAccount = account;
                            if (SelectedAccount.Admin == true)
                            {
                                VisibilityAdminPanel = "Visible";
                            }
                            else
                            {
                                VisibilityAdminPanel = "Hidden";
                            }
                            VisibilityAccount = "Visible";
                            VisibilityError = "Hidden";
                        }
                        else
                            VisibilityError = "Visible";


                    }, x => !String.IsNullOrEmpty(Login) && SelectedAccount == null);
                return _authorithation;
            }
        }

        public ICommand LogOut
        {
            get
            {
                if (_logOut == null)
                    _logOut = new RelayCommand(x =>
                    {
                        SelectedAccount = null;
                        VisibilityAdminPanel = "Hidden";
                        VisibilityAccount = "Hidden";
                    }, x => SelectedAccount != null);
                return _logOut;
            }
        }

        public ICommand ViewCommand
        {
            get
            {
                if (_viewCommand == null)
                    _viewCommand = new RelayCommand(x => { FindSelectedItem((string)x); OpenWatch(); });
                return _viewCommand;
            }
        }

        public ICommand SortCommand => _sortCommand ?? (_sortCommand = new RelayCommand(
            param =>
            {
                string SortParam = param.ToString();
                FilterCommand.SortDescriptions.Clear();
                FilterCommand.SortDescriptions.Add(new SortDescription(SortParam, ListSortDirection.Ascending));
            }
            ));

        public ICommand Expand
        {
            get
            {
                if (_expand == null)
                    _expand = new RelayCommand(x => FindSelectedItem((string)x));
                return _expand;
            }
        }

        public ICommand UpdateListCommand
        {
            get
            {
                if (_updateList == null)
                    _updateList = new RelayCommand(x => { FindSelectedItem((string)x); Animes = new ObservableCollection<FullAnimeDTO>(Animes); });
                return _updateList;
            }
        }

        public ICommand OpendCommand
        {
            get
            {
                if (_openCommand == null)
                    _openCommand = new RelayCommand(x =>
                    {
                        FilterCommand = CollectionViewSource.GetDefaultView(Animes);
                        FilterCommand.Filter = MoviesFilter;
                        Notify(nameof(FilterCommand));
                    });
                return _openCommand;
            }
        }

        #endregion
        #region  Method


        private bool Filter(object obj)
        {
            var anime = obj as AnimeDTO;
            var isContains = true;
            if (!string.IsNullOrEmpty(_searchFilter) && !string.IsNullOrWhiteSpace(_searchFilter))
            {
                isContains = anime?.Name?.Contains(_searchFilter) ?? false;
            }

            return isContains;
        }

        private void FindSelectedItem(object parametr)
        {
            foreach (var i in Animes)
            {
                if (parametr as string == i.Name)
                {
                    SelectedAnime = i;
                    SingleSelected.AnimeSelected = i;
                    break;
                }
            }
        }
        private void SortMethod(object param)
        {
            string sortParam = param.ToString();
            FilterCommand.SortDescriptions.Clear();
            FilterCommand.SortDescriptions.Add(new SortDescription(sortParam, ListSortDirection.Ascending));
        }

        private void OpenWatch()
        {
            InfoAnimeView win2 = new InfoAnimeView();
            win2.ShowDialog();
        }

        private bool MoviesFilter(object o)
        {
            var movieInfo = o as AnimeDTO;
            bool isCintainsTitle = true;
            if (!string.IsNullOrWhiteSpace(_searchFilter) && !string.IsNullOrEmpty(_searchFilter))
            {
                isCintainsTitle = movieInfo.Description.Contains(_searchFilter);
            }
            return isCintainsTitle;
        }
        #endregion
        #region Load
        private async void LoadAnimes()
        {
            var animes = await _animeService.GetAllAsync();
            Animes = new ObservableCollection<FullAnimeDTO>(animes);

            var accounts = await _accountService.GetAllAsync();
            Accounts = new ObservableCollection<AccountDTO>(accounts);

            var avtors = await _avtorService.GetAllAsync();
            Avtors = new ObservableCollection<AvtorDTO>(avtors);

            var series = await _seriesService.GetAllAsync();
            Series = new ObservableCollection<SeriesDTO>(series);

            FilterCommand = CollectionViewSource.GetDefaultView(_animes);
            FilterCommand.Filter = Filter;
        }
        #endregion
    }
}
