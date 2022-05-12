using Microsoft.AspNetCore.Http;

namespace ComputersStore.Models.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public string ReturnUrl { get; set; }
    }
}
