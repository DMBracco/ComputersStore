using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ComputersStore.Models;

namespace ComputersStore.Components {

    public class NavigationMenuViewComponent : ViewComponent {
        private IStoreRepository repository;

        public NavigationMenuViewComponent(IStoreRepository repo) {
            repository = repo;
        }

        public IViewComponentResult Invoke(string selected) {
            ViewBag.SelectedCategory = selected;
            return View(repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
