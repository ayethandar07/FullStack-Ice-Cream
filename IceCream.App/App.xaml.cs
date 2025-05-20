using IceCream.App.Services;

namespace IceCream.App
{
    public partial class App : Application
    {
        public App(AuthService authService)
        {
            InitializeComponent();

            authService.Initialize();
            MainPage = new AppShell(authService);
        }
    }
}
