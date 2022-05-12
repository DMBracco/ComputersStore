using ComputersStore.Models;
using ComputersStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ComputersStore.Controllers
{
    public class CatalogController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 4;

        public CatalogController(IStoreRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string category, int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Products.Count() :
                        repository.Products.Where(e =>
                            e.Category == category).Count()
                },
                CurrentCategory = category
            });

        public ViewResult Details(int id, string returnUrl)
        {
            var product = repository.Product(id);

            var productView = new ProductViewModel
            {
                Product = new Product
                {
                    ProductID = product.ProductID,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Category = product.Category,
                    Image = product.Image
                },
                ReturnUrl = returnUrl
            };

            return View(productView);
        }
    }
}
