using DevineMoi_.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DevineMoi_.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		public ItemDetailPage()
		{
			InitializeComponent();
			BindingContext = new ItemDetailViewModel();
		}
	}
}