using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IceCream.App.Models;
using IceCream.Shared.Dtos;

namespace IceCream.App.ViewModels;

// detailsPage?Icecream=VALUE
[QueryProperty(nameof(Icecream), nameof(Icecream))]
public partial class DetailsViewModel: BaseViewModel
{
    [ObservableProperty]
    private IcecreamDto? _icecream;

    [ObservableProperty]
    private int _quantity;

    [ObservableProperty]
    private IcecreamOption[] _options = [];

    partial void OnIcecreamChanged(IcecreamDto? value)
    {
        Options = [];
        if (value is null)
            return;

        Options = value.Options.Select(x => new IcecreamOption
        {
            Flavor = x.Flavor,
            Topping = x.Topping,
            IsSelected = false
        }).ToArray();
    }

    [RelayCommand]
    private void IncreaseQuantity() => Quantity++;

    [RelayCommand]
    private void DecreaseQuantity()
    {
        if (Quantity > 0)
            Quantity--;
    }

    [RelayCommand]
    private async Task GoBackAsync() => await GoToAsync("..", animate: true);

    [RelayCommand]
    private void SelectOption(IcecreamOption newOption)
    {        
        var newIsSelected = !newOption.IsSelected;
        // Deselect all options
        Options = [.. Options.Select(o => { o.IsSelected = false; return o; })];
        newOption.IsSelected = newIsSelected;
    }
}
