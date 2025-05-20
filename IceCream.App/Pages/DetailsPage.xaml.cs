using IceCream.App.ViewModels;

namespace IceCream.App.Pages;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(DetailsViewModel detailsViewModel)
	{
		InitializeComponent();
		BindingContext = detailsViewModel;
	}
}