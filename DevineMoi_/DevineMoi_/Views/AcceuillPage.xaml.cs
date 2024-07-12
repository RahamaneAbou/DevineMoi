using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DevineMoi_.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AcceuillPage : ContentPage
	{
		public AcceuillPage()
		{
			InitializeComponent();
		}

		// la methode du premier buttin
		private void Btn_Clicked(Object sender,EventArgs e)
		{
			this.Navigation.PushAsync(new JeuxPage());
		}
	}
}