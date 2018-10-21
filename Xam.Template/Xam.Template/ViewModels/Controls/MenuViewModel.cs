using System;
using System.Windows.Input;
using Rene.Xam.Extensions.ViewModelHelper;

namespace Xam.Template.ViewModels.Controls
{
    public class MenuViewModel :ViewModelBase
    {

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

      
        public ICommand Expedientes_click { get; set; }
        
        public ICommand Exit_click { get; set; }
        public ICommand About_click { get; set; }
        public ICommand Configuration_click { get; set; }
        public ICommand LoginLogOut_click { get; set; }
        public ICommand Vuelos_click { get; set; }
        


     

        #endregion

        public MenuViewModel()
        {
            //_navigationService = navigationService;
            //_dialogService = pageDialogService;
            //_userSettings = UserSettings.Instance;

            Initialize();
        }

        #region Private

        private void Initialize()
        {

            //LoginLogOut_click = new DelegateCommand(OnLoginLogOut_click);


            //Expedientes_click = new DelegateCommand(OnExpedientes_click);
            //Vuelos_click = new DelegateCommand(OnVuelos_click);

            //Configuration_click = new DelegateCommand(OnConfiguration_click);
            //Exit_click = new DelegateCommand(OnExit_click);

            //About_click = new DelegateCommand(OnAbout_click);


            //VisibleNoAnonymous = IsLogging = _userSettings.IsLogging;




            Debug = false;
#if DEBUG
            Debug = true;
#endif


        }


        #endregion

        #region Events


        private async void OnExpedientes_click()
        {
         //   await _navigationService.PushPageWithMenuAsync<object>(nameof(ExpedienteListPage), null);
            //  Application.Current.MainPage.Navigation.PushModalAsync<MainPage, StartPage>();
        }

        private async void OnVuelos_click()
        {
            //   await _navigationService.PushPageWithMenuAsync<object>(nameof(VuelosListPage), null);
        }

        private async void OnConfiguration_click()
        {
            //     await _navigationService.PushPageWithMenuAsync<object>(nameof(ConfiguracionPage), null);

        }
        private async void OnLoginLogOut_click()
        {
            //if (!_userSettings.IsLogging || String.IsNullOrEmpty(User.Login))
            //{
            //    await _navigationService.PushPageWithMenuAsync<object>(nameof(LoginPage), null);
            //}
            //else
            //{
            //    var cerrar = await _dialogService.DisplayAlertAsync("ATENCION", "Estás a punto de cerrar sesión, ¿deseas continuar?", "Sí", "No");

            //    if (!cerrar) return;

            //    _userSettings.Logout();

            //    await _navigationService.PushPageWithMenuAsync<object>(nameof(LoginPage), null);

            //}
        }



        private async void OnAbout_click()
        {
            //await _navigationService.PushPageWithMenuAsync<object>(nameof(AboutPage), null);
            ////_navigationService.PushPageWithMenuAsync<object>(nameof(AAAPruebasPage), null);
        }


        private async void OnExit_click()
        {
            //var result = await _dialogService.DisplayAlertAsync("ATENCION", "Estás a punto de cerrar la aplicación, ¿deseas continuar?", "Sí", "No");

            //if (result)
            //{
            //    //var closeService = Xamarin.Forms.DependencyService.Get<ICloseApplication>();
            //    //closeService.Close();
            //}
        }

        #endregion
    }
}

