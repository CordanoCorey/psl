using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psl.API.Features.Products
{
    public interface IProductsService
    {
        IEnumerable<ProductModel> GetProducts(int userId);
        ProductModel GetProduct(int id);
        ProductModel AddProduct(ProductModel model);
        ProductModel UpdateProduct(ProductModel model);
        void DeleteProduct(int id);
    }

    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _repo;

        public ProductsService(IProductsRepository repo)
        {
            _repo = repo;
        }

        public ProductModel AddProduct(ProductModel model)
        {
            var inserted = _repo.Insert(model);
            return GetProduct(inserted.Id);
        }

        public void DeleteProduct(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<ProductModel> GetProducts(int userId)
        {
            return _repo.All();
        }

        public ProductModel GetProduct(int id)
        {
            return _repo.FindByKey(id);
        }

        public ProductModel UpdateProduct(ProductModel model)
        {
            var updated = _repo.Update(model);
            return GetProduct(updated.Id);
        }
    }
}
