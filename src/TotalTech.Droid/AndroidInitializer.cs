using System;
using System.Collections.Generic;
using System.Linq;
using Prism;
using Prism.Ioc;
using Android.App;
using Microsoft.Identity.Client;

namespace TotalTech.Droid
{
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register Any Platform Specific Implementations that you cannot 
            // access from Shared Code
            containerRegistry.RegisterInstance(new UIParent(Xamarin.Forms.Forms.Context as Activity));
        }
    }
}
