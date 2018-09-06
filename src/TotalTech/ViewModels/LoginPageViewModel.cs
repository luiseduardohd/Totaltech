using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Logging;
using Prism.Services;
using DependencyService = Xamarin.Forms.DependencyService;
using TotalTech.DependencyServices;

namespace TotalTech.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public DelegateCommand StatesViewCommand { get; set; }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeviceService deviceService) : base(navigationService, pageDialogService, deviceService)
        {
            StatesViewCommand = new DelegateCommand(StartStatesView);
        }
        protected async void StartStatesView()
        {
            await _navigationService.NavigateAsync("/StatesPage");
        }
    }
}
