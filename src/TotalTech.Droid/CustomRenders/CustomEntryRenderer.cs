using System;
using System.IO;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using CoreGraphics;
using Plugin.CurrentActivity;
using TotalTech.CustomRenders;
using TotalTech.Droid.CustomRenders;
using TotalTech.iOS.CustomRenders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace TotalTech.Droid.CustomRenders
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) :base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null && Element != null)
            {
                var view = (CustomEntry)Element;

                SetIcon(view);
                var _gradientBackground = new GradientDrawable();
                _gradientBackground.SetShape(ShapeType.Rectangle);
                _gradientBackground.SetColor(view.BackgroundColor.ToAndroid());

                _gradientBackground.SetStroke(view.BorderWidth,view.BorderColor.ToAndroid());
                Control.SetBackground(_gradientBackground);

                Control.SetPadding(
                    (int)DPToPixels(this.Context,Convert.ToSingle(12)),
                    Control.PaddingTop,
                    (int)DPToPixels(this.Context, Convert.ToSingle(12)),
                    Control.PaddingBottom
                );
            }
        }
        public static float DPToPixels(Context context,float valueInDP)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDP, metrics);
        }

        private void SetIcon(CustomEntry view)
        {
            if (!string.IsNullOrEmpty(view.Icon))
            {
                try
                {
                    var context = CrossCurrentActivity.Current.AppContext;
                    var resId = context.Resources.GetIdentifier(Path.GetFileNameWithoutExtension(view.Icon), "drawable", context.PackageName);
                    if (resId != 0)
                        Control.SetCompoundDrawablesWithIntrinsicBounds(resId, 0, 0, 0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Control.SetCompoundDrawablesWithIntrinsicBounds(0, 0, 0, 0);
            }
        }
    }
}