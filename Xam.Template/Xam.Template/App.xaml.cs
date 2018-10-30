using System;
using Arpas.App.AppBootstrapping.RegisterModules;
using Autofac;
using Rene.Xam.Extensions.Bootstrapping;
using Rene.Xam.Extensions.Bootstrapping.Modules;
using Xam.Template.ViewModels;
using Xam.Template.ViewModels.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xam.Template.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Xam.Template
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            this.Setup()
                .RegisterDependencies(builder =>
                {
                    builder.RegisterModule<ViewModelViewRegistrationModule>();
                    builder.RegisterModule<ServicesRegistrationModule>();
                })
                .RegisterViews(reg =>
                {
                   

                })
                .Configuere(conf =>
                {
                    // https://forums.xamarin.com/discussion/47444/best-practice-mvvm-navigation-using-master-detail-page
                    //https://github.com/adamped/xarch-starter
                  // conf.UseMasterDetailMode<MenuViewModel,PruebaViewModel>();
                    conf.SetStartupView<PageOneViewModel>();
                })
                .Build();
          

            //   MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
