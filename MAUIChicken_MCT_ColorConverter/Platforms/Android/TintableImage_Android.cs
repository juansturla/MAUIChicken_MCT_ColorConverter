using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using Android.Widget;
using Android.Graphics;
using Color = Microsoft.Maui.Graphics.Color;
using Microsoft.Maui;

namespace MAUIChicken_MCT_ColorConverter.MyImage
{
    public partial class TintableImage:Image
    {
        partial void ChangeColor(Color newValue)
        {
            var image = this;
            var androidImage = image.Handler.NativeView as ImageView;
            if (newValue == Colors.Transparent)
            {
                androidImage.ClearColorFilter();
            }
            else
            {
                Console.WriteLine("Changing to a new color Android");
                androidImage.SetColorFilter(new PorterDuffColorFilter(newValue.ToNative(), PorterDuff.Mode.SrcIn ?? throw new NullReferenceException()));
                androidImage.RefreshDrawableState();
            }
        }
    }
}
