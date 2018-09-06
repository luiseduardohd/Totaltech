using System;
using System.Threading.Tasks;
using TotalTech.Resources;
using TotalTech.Services;
using TotalTech.Views;
using Plugin.Multilingual;
using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using DryIoc;
using Prism.DryIoc;
using Microsoft.Identity.Client;
using TotalTech.Helpers;
using Realms;
using Realms.Sync;
using Prism.Logging;
using Xamarin.Forms;

using DebugLogger = TotalTech.Services.DebugLogger;

namespace TotalTech
{
    public partial class App : PrismApplication
    {
        public static Realm realm;
  
        public App()
            : this(null)
        {
        }

        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            LogUnobservedTaskExceptions();
            AppResources.Culture = CrossMultilingual.Current.DeviceCultureInfo;

            Device.BeginInvokeOnMainThread(() => {
                realm = Realm.GetInstance(AppConstants.RealmPath);
            });

            await NavigationService.NavigateAsync("SplashScreenPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register the Popup Plugin Navigation Service
            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.RegisterInstance(CreateLogger());
   
            var config = RealmConfiguration.DefaultConfiguration;
            containerRegistry.GetContainer().Register(reuse: Reuse.Transient,
                               made: Made.Of(() => Realm.GetInstance(config)),
                               setup: Setup.With(allowDisposableTransient: true));


            // Navigating to "TabbedPage?createTab=ViewA&createTab=ViewB&createTab=ViewC will generate a TabbedPage
            // with three tabs for ViewA, ViewB, & ViewC
            // Adding `selectedTab=ViewB` will set the current tab to ViewB
            containerRegistry.RegisterForNavigation<TabbedPage>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SplashScreenPage>();
            containerRegistry.RegisterForNavigation<LoginPage>();
            containerRegistry.RegisterForNavigation<StatesPage>();
            containerRegistry.RegisterForNavigation<MapPage>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle IApplicationLifecycle
            base.OnSleep();

            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle IApplicationLifecycle
            base.OnResume();

            // Handle when your app resumes
        }

        private ILoggerFacade CreateLogger() =>
            new DebugLogger();

        private void LogUnobservedTaskExceptions()
        {
            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                Container.Resolve<ILoggerFacade>().Log(e.Exception);
            };
        }
    }
}
