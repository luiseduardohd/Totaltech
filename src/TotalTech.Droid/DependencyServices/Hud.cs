using System;
using Android.App;
using Android.Content;
using AndroidHUD;
using Plugin.CurrentActivity;
using TotalTech.DependencyServices;
using TotalTech.Droid.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(Hud))]
namespace TotalTech.Droid.DependencyServices
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
                AndHUD.Shared.Show(CrossCurrentActivity.Current.Activity);
            });
        }

        public void Hide()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                AndHUD.Shared.Dismiss(CrossCurrentActivity.Current.Activity);
            });
        }
    }
}
