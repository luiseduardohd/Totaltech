using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Logging;
using Prism.Services;
using Xamarin.Forms.Maps;
using TotalTech.Models;
using TotalTech.Helpers;

namespace TotalTech.ViewModels
{
    public class MapPageViewModel : ViewModelBase
    {
        public Map Map { get; private set; }

        private Geocoder geoCoder;

        public MapPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeviceService deviceService) : base(navigationService, pageDialogService, deviceService)
        {
            Map = new Map();
            geoCoder = new Geocoder();
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            switch (parameters.GetNavigationMode())
            {
                case NavigationMode.Back:
                    break;
                case NavigationMode.New:
                    break;
            }
            await PositionMap((State)parameters["state"]);
        }
        protected async Task PositionMap(State state)
        {
            var positions = await geoCoder.GetPositionsForAddressAsync(state.name);
            Map.MoveToRegion(
                 MapSpan.FromCenterAndRadius(
                    positions.FirstOrDefault(),
                      Distance.FromMiles(1)));
        }

    }
}
