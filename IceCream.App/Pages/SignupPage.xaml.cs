using IceCream.App.ViewModels;

namespace IceCream.App.Pages;

public partial class SignupPage : ContentPage
{
	public SignupPage(AuthViewModel authViewModel)
	{
		InitializeComponent();
		BindingContext = authViewModel;
	}

    private async void SigninLabel_Tapped(object sender, TappedEventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(SigninPage));
    }
}