using IceCream.App.ViewModels;

namespace IceCream.App.Pages;

public partial class SigninPage : ContentPage
{
	public SigninPage(AuthViewModel authViewModel)
	{
		InitializeComponent();
        BindingContext = authViewModel;
	}

    private async void SignupLabel_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignupPage));
    }
}