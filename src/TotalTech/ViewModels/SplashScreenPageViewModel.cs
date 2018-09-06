using System.Threading.Tasks;
using Prism.AppModel;
using Prism.Navigation;
using Prism.Services;

namespace TotalTech.ViewModels
{
    public class SplashScreenPageViewModel : ViewModelBase
    {
        public SplashScreenPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeviceService deviceService)
            : base(navigationService, pageDialogService, deviceService)
        {
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {

            await Task.Delay(4000);

            await _navigationService.NavigateAsync("/NavigationPage/LoginPage");
        }
    }
}