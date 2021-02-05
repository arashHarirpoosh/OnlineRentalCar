using Microsoft.AspNetCore.Mvc;
using CarRentalProject.Models;
using System.Linq;
using CarRentalProject.Models.ViewModels;


namespace CarRentalProject.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 4;

        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string category, int productPage = 1)
            => View(new ProductsListViewModel
            {
                Cars = repository.Cars
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.CarID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Cars.Count() :
                        repository.Cars.Where(e =>
                            e.Category == category).Count()
                },
                CurrentCategory = category
            });
    }
}
