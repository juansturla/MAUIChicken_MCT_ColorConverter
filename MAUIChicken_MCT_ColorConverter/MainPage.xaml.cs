using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using Microsoft.Maui.Graphics;

namespace MAUIChicken_MCT_ColorConverter
{
    public partial class MainPage : ContentPage
    {
        readonly Dictionary<string, Color> _colors = typeof(Colors)
       .GetFields(BindingFlags.Static | BindingFlags.Public)
       .ToDictionary(c => c.Name, c => (Color)(c.GetValue(null) ?? throw new InvalidOperationException()));

        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            myCollectionView.ItemsSource = _colors.Values.ToList();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            tintableImage.TintColor = _colors.Values.ToList()[new Random().Next(_colors.Count)];
        }

        private void Clear(object sender, EventArgs e)
        {
            tintableImage.TintColor = Colors.Transparent;
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            try
            {
                Console.WriteLine("Event fired with " + e.ToString());
                TappedEventArgs tappedEventArgs = e as TappedEventArgs;
                Console.WriteLine((tappedEventArgs.Parameter as Color).ToString());
                tintableImage.TintColor = tappedEventArgs.Parameter as Color;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ex: " + ex.Message);

            }
        }

        void myCollectionView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                Console.WriteLine("Type is ", e.GetType().ToString());
                Console.WriteLine("Event fired with " + e.CurrentSelection.ToString());
                Color selectedColor = (Color)e.CurrentSelection.FirstOrDefault();
                Console.WriteLine(selectedColor.ToString());
                tintableImage.TintColor = selectedColor;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ex: " + ex.Message);

            }
        }
    }
}
