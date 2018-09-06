using System;
using Xamarin.Forms;

namespace TotalTech.CustomRenders
{
	public class CustomEntry : Entry
    {
        public static readonly BindableProperty IconProperty = 
            BindableProperty.Create(
                nameof(Icon), 
                typeof(string), 
                typeof(CustomEntry), 
                string.Empty);


        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(
                nameof(BorderColor),
                typeof(Color),
                typeof(CustomEntry),
                Color.Gray
            );

        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(
                nameof(BorderWidth),
                typeof(int),
                typeof(CustomEntry),
                1
            );

        public string Icon
        {
            get {
                return (string)GetValue(IconProperty);
            }
            set
            {
                SetValue(IconProperty, value);
            }
        }

        public Color BorderColor
        {
            get
            {
                return (Color)GetValue(BorderColorProperty);
            }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }

        public int BorderWidth
        {
            get
            {
                return (int)GetValue(BorderWidthProperty);
            }
            set
            {
                SetValue(BorderWidthProperty, value);
            }
        }

    }
}
