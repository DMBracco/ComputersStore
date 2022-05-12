using System.Linq;

namespace ComputersStore.Models {
    public interface IStoreRepository {

        IQueryable<Product> Products { get; }
        public Product Product(int productId);

        void SaveProduct(Product p);
        void CreateProduct(Product p);
        void DeleteProduct(Product p);
        Product DeleteProduct(int productID);
        void AddImg(long productId, byte[] imageData);
    }
}
