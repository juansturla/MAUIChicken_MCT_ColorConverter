using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using UIKit;
using Color = Microsoft.Maui.Graphics.Color;

namespace MAUIChicken_MCT_ColorConverter.MyImage
{
    public partial class TintableImage : Image
    {
        partial void ChangeColor(Color newValue)
        {
            var image = this;
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
        }
    }
}
