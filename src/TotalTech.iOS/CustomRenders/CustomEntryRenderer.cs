using System;
using CoreGraphics;
using TotalTech.CustomRenders;
using TotalTech.iOS.CustomRenders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace TotalTech.iOS.CustomRenders
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null && Element!=null)
            {
                var view = (CustomEntry)Element;

                SetIcon(view);
                Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
                Control.ReturnKeyType = UIReturnKeyType.Done;
                Control.Layer.BorderColor = view.BorderColor.ToCGColor();
                Control.Layer.BorderWidth = view.BorderWidth;
                Control.ClipsToBounds = true;
                Control.BorderStyle = UITextBorderStyle.Line;
                Control.TintColor = view.BorderColor.ToUIColor();
                Control.TextColor = UIColor.Black;
                Control.BackgroundColor = UIColor.White;
            }
        }

        void SetIcon(CustomEntry view)
        {
            if (!string.IsNullOrEmpty(view.Icon))
            {
                Control.LeftViewMode = UITextFieldViewMode.Always;
                var uiImageView = new UIImageView();
                var image = UIImage.FromBundle(view.Icon);
                uiImageView.Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                uiImageView.Frame = new CGRect(0, 0, 16, 16);
                uiImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
                Control.LeftView = uiImageView;
            }
            else
            {
                Control.LeftViewMode = UITextFieldViewMode.Never;
                Control.LeftView = null;
            }
        }
    }
}
