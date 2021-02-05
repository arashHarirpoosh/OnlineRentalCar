using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalProject.Pages
{
    public class CartModel : PageModel
    {
        private IStoreRepository repository;

        public CartModel(IStoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long carID, string returnUrl)
        {
            Car car = repository.Cars
                .FirstOrDefault(p => p.CarID == carID);
            Cart.AddItem(car, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long carId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Car.CarID == carId).Car);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
