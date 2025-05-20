using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IceCream.App.Pages;
using IceCream.App.Services;
using IceCream.Shared.Dtos;

namespace IceCream.App.ViewModels;

public partial class AuthViewModel(IAuthApi authApi, AuthService authService) : BaseViewModel
{
    private readonly IAuthApi _authApi = authApi;
    private readonly AuthService _authService = authService;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignup))]
    private string? _name;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignin)), NotifyPropertyChangedFor(nameof(CanSignup))]
    private string? _email;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignin)), NotifyPropertyChangedFor(nameof(CanSignup))]
    private string? _password;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignup))]
    private string? _address;

    public bool CanSignin => !string.IsNullOrEmpty(Email)
                           && !string.IsNullOrEmpty(Password);
    public bool CanSignup => CanSignin
                           && !string.IsNullOrEmpty(Name)
                           && !string.IsNullOrEmpty(Address);

    [RelayCommand]
    private async Task SignupAsync()
    {
        IsBusy = true;
        try
        {
            var signupDto = new SignupRequestDto(Name, Email, Password, Address);
            var result = await _authApi.SignupAsync(signupDto);

            if (result.IsSuccess)
            {
                _authService.Signin(result.Data);

                // Navigate to Home page
                await GoToAsync($"//{nameof(HomePage)}", animate: true);
            }
            else
            {
                // Dispaly error Alert
                await ShowErrorAlertAsync(result.ErrorMessage ?? "Unknown error in signing up");
            }
        }
        catch (Exception ex)
        {
            await ShowErrorAlertAsync(ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task SigninAsync()
    {
        IsBusy = true;
        try
        {
            var signinDto = new SigninRequestDto(Email, Password);
            var result = await _authApi.SigninAsync(signinDto);

            if (result.IsSuccess)
            {
                _authService.Signin(result.Data);
                // Navigate to Home page
                await GoToAsync($"//{nameof(HomePage)}", animate: true);
            }
            else
            {
                // Dispaly error Alert
                await ShowErrorAlertAsync(result.ErrorMessage ?? "Unknown error in signing up");
            }
        }
        catch (Exception ex)
        {
            await ShowErrorAlertAsync(ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
