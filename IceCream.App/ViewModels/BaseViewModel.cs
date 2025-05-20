using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;

namespace IceCream.App.ViewModels;

public partial class BaseViewModel: ObservableObject
{
    [ObservableProperty]
    private bool _isBusy;

    protected static async Task GoToAsync(string url, bool animate = false) =>
        await Shell.Current.GoToAsync(url, animate);

    protected static async Task GoToAsync(string url, bool animate, IDictionary<string, object> parameter) =>
        await Shell.Current.GoToAsync(url, animate, parameter);

    protected static async Task ShowErrorAlertAsync(string errorMessage) =>
        await Shell.Current.DisplayAlert("Error", errorMessage, "Ok");

    protected static async Task ShowAlertAsync(string message) =>
        await Shell.Current.DisplayAlert("Alert", message, "Ok");

    protected static async Task ShowToastAsync(string message) => await Toast.Make(message).Show();
}
