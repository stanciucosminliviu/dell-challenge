using System.Collections.Generic;
using System.Linq;
using DellChallenge.D1.Api.Dto;

namespace DellChallenge.D1.Api.Dal
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsContext _context;

        public ProductsService(ProductsContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Products.Select(p => MapToDto(p));
        }

        public ProductDto Add(NewProductDto newProduct)
        {
            var product = MapToData(newProduct);
            _context.Products.Add(product);
            _context.SaveChanges();
            var addedDto = MapToDto(product);
            return addedDto;
        }

        public string Delete(string id)
        {
            Product objectFromDb = _context.Products.FirstOrDefault(x => x.Id == id);
            if (objectFromDb != null)
            {
                _context.Products.Remove(objectFromDb);
                _context.SaveChanges();

                return "Success";
            }

            return null;
        }

        public ProductDto GetById(string productId)
        {
            Product productFromDb = _context.Products.FirstOrDefault(x => x.Id == productId);

            if (productFromDb != null)
            {
                return (MapToDto(productFromDb));
            }

            return null;
        }

        public ProductDto EditProduct(string id, NewProductDto productToEdit)
        {
            Product productFromDb = _context.Products.FirstOrDefault(x => x.Id == id);

            if (productFromDb != null)
            {
                productFromDb.Name = productToEdit.Name;
                productFromDb.Category = productToEdit.Category;

                _context.SaveChanges();

                return MapToDto(productFromDb);
            }

            return null;
        }

        #region Mappers
        private Product MapToData(NewProductDto newProduct)
        {
            return new Product
            {
                Category = newProduct.Category,
                Name = newProduct.Name
            };
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }
        #endregion
    }
}
