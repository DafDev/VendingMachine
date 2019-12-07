using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DafCompany.VendingMachine.App.Loaders;
using DafCompany.VendingMachine.App.Models;

namespace DafCompany.VendingMachine.App.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductLoader _productLoader;
        private List<ProductStack> _productStacksInMemoryRepo; 
        public ProductRepository(IProductLoader productLoader)
        {
            _productLoader = productLoader;
            _productStacksInMemoryRepo = StoreProductsFromLoader().ToList();
            SortRepository();
        }

        private void SortRepository()
        {
            int i = 0;
            _productStacksInMemoryRepo.ForEach(p => p.Product.Id = i++);
        }

        public Product GetProduct(int id)
        {
            Product product = _productStacksInMemoryRepo.FirstOrDefault(p => p.Product.Id == id).Product;
            if (product != null)
            {
                _productStacksInMemoryRepo.FirstOrDefault(p => p.Product.Id == id).Count--;
            }
            return product;
        }

        public IEnumerable<ProductStack> StoreProductsFromLoader()
        {
            return _productLoader.LoadAll();
        }

        public ProductStack GetProductStackFromLoader(Product product, int count)
        {
            ProductStack productStack = _productLoader.LoadProduct(product, count);
            if (_productStacksInMemoryRepo.Any(p => p.Product.Name == product.Name))
            {
                _productStacksInMemoryRepo.First(p => p.Product.Name == product.Name).Count += productStack.Count;
            }
            else
            {
                _productStacksInMemoryRepo.Add(productStack);
            }
            return productStack;
        }
    }
}
