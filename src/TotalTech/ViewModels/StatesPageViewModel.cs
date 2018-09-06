using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using Realms;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using DependencyService = Xamarin.Forms.DependencyService;
using TotalTech.Models;
using TotalTech.DependencyServices;
using System.Threading;
using TotalTech.Helpers;
using Acr.UserDialogs;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;

namespace TotalTech.ViewModels
{
    public class StatesPageViewModel : ViewModelBase
    {
        static new string Title => "States";

        protected IEnumerable<State> _items ;
        protected State _selectedItem;


        public IEnumerable<State> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged();
            }
        }

        public State SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
            }
        }

        public ICommand ShowMapCommand { get; private set; }


        public StatesPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeviceService deviceService) : base(navigationService, pageDialogService, deviceService)
        {
            ShowMapCommand = new Command<State>(ShowMap);

            Device.BeginInvokeOnMainThread(() => {
                Items = App.realm.All<State>().OrderBy(u => u.name);
            });
        }

        protected void ShowMap(State state)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("state", state);
            _navigationService.NavigateAsync("/NavigationPage/StatesPage/MapPage", navigationParams);
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            var hud = DependencyService.Get<IHud>();
            hud.Show();
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            await Reload(this);
        }

        protected async Task Reload(StatesPageViewModel instance)
        {
            var hud = DependencyService.Get<IHud>();
            await Task.Run(() => {
                try
                {
                    Thread.Sleep(100);
                    instance.ReloadItems();
                    hud.Hide();
                }
                catch (Exception e)
                {
                    hud.Hide();
                    UserDialogs.Instance.Alert("Exception:" + e.Message, "Error", "Ok");
                }
            });
        }

        public void ReloadItems()
        {
            var states = DownloadStates();

            Device.BeginInvokeOnMainThread(() => {

                if (App.realm.All<State>().Count() > 0)
                {
                    return;
                }

                App.realm.Write(() =>
                {
                    foreach (var state in states)
                    {
                        App.realm.Add(new State
                        {
                            id = state.id,
                            name = state.name
                        });
                    }
                });
            });
        }
        protected List<State> DownloadStates()
        {
            var states = new List<State>();
            try
            {
                var webClient = new WebClient();
                var url = AppConstants.StatesUrl;
                var statesJsonString = webClient.DownloadString(url);

                Thread.Sleep(2000);

                states = JsonConvert.DeserializeObject<List<State>>(statesJsonString);
            }
            catch(Exception e)
            {
                UserDialogs.Instance.Alert("Exception:" + e.Message, "Error", "Ok");
            }
            return states;
        }
    }
}
