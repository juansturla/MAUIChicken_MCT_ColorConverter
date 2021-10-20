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
			count++;
			CounterLabel.Text = $"Current count: {count}";

			SemanticScreenReader.Announce(CounterLabel.Text);

			tintableImage.TintColor = _colors.Values.ToList()[new Random().Next(_colors.Count)];
		}

		private void Clear(object sender, EventArgs e)
        {
			tintableImage.TintColor = Colors.Transparent;
        }
	}
}
