using DevineMoi_.Services;
using DevineMoi_.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DevineMoi_
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			DependencyService.Register<MockDataStore>();
			MainPage = new NavigationPage(new AcceuillPage());
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
