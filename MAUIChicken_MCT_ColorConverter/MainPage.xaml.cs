using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using Microsoft.Maui.Graphics;

namespace MAUIChicken_MCT_ColorConverter
{
	public partial class MainPage : ContentPage
	{
		int count = 0;

		public MainPage()
		{
			InitializeComponent();
		}

		private void OnCounterClicked(object sender, EventArgs e)
		{
			count++;
			CounterLabel.Text = $"Current count: {count}";

			SemanticScreenReader.Announce(CounterLabel.Text);

			tintableImage.TintColor = new Color(new Random().Next(255), new Random().Next(255), new Random().Next(255));
		}

		private void Clear(object sender, EventArgs e)
        {
			tintableImage.TintColor = Colors.Transparent;
        }
	}
}
