using Microsoft.AspNetCore.Mvc;
using ComputersStore.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using ComputersStore.Models.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ComputersStore.Controllers {

    [Authorize]
    public class AdminController : Controller {
        private IStoreRepository repository;

        public AdminController(IStoreRepository repo) {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Products);

        public ViewResult Edit(int productId) =>
            View(repository.Products
                .FirstOrDefault(p => p.ProductID == productId));
        
        [HttpPost]
        public IActionResult Edit(Product product) {
            if (ModelState.IsValid) {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            } else {
                // there is something wrong with the data values
                return View(product);
            }
        }

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public IActionResult Delete(int productId) {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null) {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddFile(long productId, IFormFile ImageIFormFile)
        {
            var product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            byte[] imageData = null;
            if (product != null)
            {
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(ImageIFormFile.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)ImageIFormFile.Length);
                }
                repository.AddImg(productId, imageData);
                TempData["message"] = $"{product.Name} has been saved";
            }
            

            return RedirectToAction("Index");
        }
    }
}
