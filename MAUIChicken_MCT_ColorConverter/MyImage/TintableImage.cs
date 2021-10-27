using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
#if __IOS__
using UIKit;
#endif

namespace MAUIChicken_MCT_ColorConverter.MyImage
{
    public partial class TintableImage : Image
    {
        public static readonly BindableProperty TintColorProperty
        = BindableProperty.CreateAttached("TintColor", typeof(Color), typeof(TintableImage), Colors.Transparent
            );

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

                ChangeColor((Color)value);
                SetValue(TintColorProperty, value);
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            try
            {
                    ChangeColor(TintColor);
            } catch (Exception ex)
            {

            }
        }

        partial void ChangeColor(Color newValue);
        /*
        {
            var image = this;
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
        */
    }
}
