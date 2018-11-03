using System;
using Autofac;
using Rene.Xam.Extensions.Bootstrapping;
using Xam.Template.Samples.RegisterModules;
using Xam.Template.Samples.ViewModels;
using Xam.Template.Samples.ViewModels.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xam.Template.Samples.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Xam.Template.Samples
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
                .Configure(conf =>
                {
                    // https://forums.xamarin.com/discussion/47444/best-practice-mvvm-navigation-using-master-detail-page
                    //https://github.com/adamped/xarch-starter
                    // conf.UseMasterDetailMode<MenuViewModel, ItemsViewModel>();
                    // conf.SetStartupView<PageOneViewModel>();
                    //MainPage = new MainPage();

                    conf.SetStartupView(new MainPage());
                })
                .Build();

           
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
