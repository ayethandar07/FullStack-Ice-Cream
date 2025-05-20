using IceCream.App.Models;
using IceCream.Shared.Dtos;
using System.Collections.ObjectModel;

namespace IceCream.App.ViewModels;

public partial class CartViewModel: BaseViewModel
{
    public ObservableCollection<CartItem> CartItems { get; set; } = [];

    public static int TotalCartCount { get; set; }
    public static event EventHandler<int>? TotalCountChanged;    

    public async void AddItemToCart(IcecreamDto icecream, int quantity, string flavor, string topping)
    {
        var existingItem = CartItems.FirstOrDefault(ci => ci.IcecreamId == icecream.Id);
        if (existingItem is not null)
        {
            if (quantity <= 0)
            {
                // user want to remove this item from the cart
                CartItems.Remove(existingItem);
                await ShowToastAsync("Icecream removed from the cart");
            }
            else
            {
                existingItem.Quantity = quantity;
                await ShowToastAsync("Quantity updated in the cart");
            }
        }
        else
        {
            var cartItem = new CartItem
            {
                FlavorName = flavor,
                IcecreamId = icecream.Id,
                Name = icecream.Name,
                Price = icecream.Price,
                Quantity = quantity,
                ToppingName = topping
            };

            CartItems.Add(cartItem);
            await ShowToastAsync("Icecream added to the cart");
        }

        TotalCartCount = CartItems.Sum(ci => ci.Quantity);
        TotalCountChanged?.Invoke(null, TotalCartCount);
    }
}
