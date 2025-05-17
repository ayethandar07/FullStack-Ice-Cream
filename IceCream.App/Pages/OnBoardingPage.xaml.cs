namespace IceCream.App.Pages;

public partial class OnBoardingPage : ContentPage
{
	public OnBoardingPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }

    private async void Signin_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SigninPage));
    }

    private async void Signup_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignupPage));
    }
}