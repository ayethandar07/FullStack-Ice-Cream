using IceCream.App.Pages;
using IceCream.App.Services;

namespace IceCream.App;

public partial class AppShell : Shell
{
    public AppShell(AuthService authService)
    {
        InitializeComponent();
        RegisterRoutes();
        _authService = authService;
    }

    private readonly static Type[] _routablePageTypes = 
        [
            typeof(SigninPage),
            typeof(SignupPage),
            typeof(MyOrdersPage),
            typeof(OrderDetailsPage),
            typeof(DetailsPage),
        ];

    private readonly AuthService _authService;

    private static void RegisterRoutes()
    {
        foreach (var pageType in _routablePageTypes)
        {
            Routing.RegisterRoute(pageType.Name, pageType);
        }
    }

    private async void FlyoutFooter_Tapped(object sender, TappedEventArgs e)
    {
        await Launcher.OpenAsync("https://github.com/ayethandar07/FullStack-Ice-Cream");
    }

    private async void SignoutMenuItem_Clicked(object sender, EventArgs e)
    {
        _authService.SignOut();
        await Shell.Current.GoToAsync($"//{nameof(OnBoardingPage)}");
    }
}
