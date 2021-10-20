using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace MAUIChicken_MCT_ColorConverter.MyImage
{
    public class TintableImage : Image
    {
        public static readonly BindableProperty TintColorProperty
        = BindableProperty.CreateAttached("TintColor", typeof(Color), typeof(TintableImage), Colors.Transparent,
            propertyChanged: OnTintColorChanged);

        public static Color GetTintColor(BindableObject view)
            => (Color)view.GetValue(TintColorProperty);

        public static void SetTintColor(BindableObject view, Color value)
            => view.SetValue(TintColorProperty, value);

        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set
            {
                Console.WriteLine("Called TintColor set");

                SetValue(TintColorProperty, value);
                ChangeColor((Color)value);
            }
        }

        static void OnTintColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var image = bindable as Image;
            Console.WriteLine("Called OnTinColorChanged");
#if __ANDROID__
            var newView = image.Handler.NativeView as Android.Widget.ImageView;
            if (newValue == TintColorProperty.DefaultValue)
            {
                newView.ClearColorFilter();
                Console.WriteLine("Default value Called, cleaning");

            }
            else
            {
                Color newColor = (Color)newValue;

                Console.WriteLine("Changing to a new color ");
                newView.SetColorFilter(new Android.Graphics.PorterDuffColorFilter(newColor.ToNative(), Android.Graphics.PorterDuff.Mode.SrcIn ?? throw new NullReferenceException()));
            }

#endif
        }
        void ChangeColor(Color newValue)
        {
            var image = this;
            Console.WriteLine("Called ChangeColor");
#if __ANDROID__
            var androidImage = image.Handler.NativeView as Android.Widget.ImageView;
            if(newValue == Colors.Transparent)
            {
                androidImage.ClearColorFilter();
            }
            else
            {
                Console.WriteLine("Changing to a new color Android");
                androidImage.SetColorFilter(new Android.Graphics.PorterDuffColorFilter(newValue.ToNative(), Android.Graphics.PorterDuff.Mode.SrcIn ?? throw new NullReferenceException()));
                androidImage.RefreshDrawableState();
            }
#endif
#if __IOS__
            var iosView = image.Handler.NativeView as UIImageView;
            if (newValue == Colors.Transparent)
            {
                iosView.Image = iosView.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
            }
            else
            {
                Console.WriteLine("Changing to a new color IOS");

                iosView.Image = iosView.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                iosView.TintColor = newValue.ToNative();
            }
#endif
        }
    }
}
