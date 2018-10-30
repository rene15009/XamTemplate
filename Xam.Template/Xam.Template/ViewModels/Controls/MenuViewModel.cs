using System;
using System.Windows.Input;
using Rene.Xam.Extensions.Base;
using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Xamarin.Forms;

namespace Xam.Template.ViewModels.Controls
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        #region Properties        

        private bool _isLogging;

        public bool IsLogging
        {
            get { return _isLogging; }
            set { SetProperty(ref _isLogging, value); }
        }

        private bool _visibleNoAnonymous;

        public bool VisibleNoAnonymous
        {
            get { return _visibleNoAnonymous; }
            set { SetProperty(ref _visibleNoAnonymous, value); }
        }

        //    public UsuarioDTO User => _userSettings.Usuario ?? new UsuarioDTO { FullName = "Invitado" };

        private bool _debug;

        public bool Debug
        {
            get { return _debug; }
            set { SetProperty(ref _debug, value); }
        }


        public ICommand PageOne_click { get; set; }
        public ICommand PageTwo_click { get; set; }

        public ICommand Exit_click { get; set; }

        public ICommand About_click { get; set; }
        public ICommand Configuration_click { get; set; }
        public ICommand LoginLogOut_click { get; set; }






        #endregion

        public MenuViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            //_dialogService = pageDialogService;
            //_userSettings = UserSettings.Instance;

            Initialize();
        }

        #region Private

        private void Initialize()
        {
            PageOne_click = new Command(async () => await _navigationService.PushAsync<PageOneViewModel>());

            PageTwo_click = new Command(async () => await _navigationService.PushAsync<PageTwoViewModel>());

            //LoginLogOut_click = new DelegateCommand(OnLoginLogOut_click);


            //Expedientes_click = new DelegateCommand(OnExpedientes_click);
            //Vuelos_click = new DelegateCommand(OnVuelos_click);

            //Configuration_click = new DelegateCommand(OnConfiguration_click);
            //Exit_click = new DelegateCommand(OnExit_click);

            //About_click = new DelegateCommand(OnAbout_click);


            //VisibleNoAnonymous = IsLogging = _userSettings.IsLogging;




        }

        #endregion
    }
}
