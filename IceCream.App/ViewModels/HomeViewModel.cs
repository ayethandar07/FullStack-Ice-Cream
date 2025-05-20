using CommunityToolkit.Mvvm.ComponentModel;
using IceCream.App.Services;
using IceCream.Shared.Dtos;

namespace IceCream.App.ViewModels;

public partial class HomeViewModel (IIcecreamApi icecreamApi, AuthService authService): BaseViewModel
{
    private readonly IIcecreamApi _icecreamApi = icecreamApi;
    private readonly AuthService _authService = authService;

    [ObservableProperty]
    private IcecreamDto[] _icecreams = [];

    [ObservableProperty]
    private string _username = string.Empty;

    private bool _isInitialized;
    public async Task InitializeAsync()
    {
        Username = _authService.User.Name;

        if (_isInitialized) return;

        IsBusy = true;
        try
        {
            _isInitialized = true;
            Icecreams = await _icecreamApi.GetIcecreamsAsync();
        }
        catch (Exception ex)
        {
            _isInitialized = false;
            await ShowErrorAlertAsync(ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
