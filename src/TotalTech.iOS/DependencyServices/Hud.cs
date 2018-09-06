using System;
using BigTed;
using TotalTech.DependencyServices;
using TotalTech.iOS.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(Hud))]
namespace TotalTech.iOS.DependencyServices
{
    public class Hud : IHud
    {
        public Hud()
        {
        }

        public void Show()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                BTProgressHUD.Show();
            });
        }

        public void Hide()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                BTProgressHUD.Dismiss();
            });
        }
    }
}
