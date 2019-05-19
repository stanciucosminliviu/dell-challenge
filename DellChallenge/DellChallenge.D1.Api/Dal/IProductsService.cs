using DellChallenge.D1.Api.Dto;
using System.Collections.Generic;

namespace DellChallenge.D1.Api.Dal
{
    public interface IProductsService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto Add(NewProductDto newProduct);
        string Delete(string id);
        ProductDto GetById(string productId);
        ProductDto EditProduct(string id, NewProductDto productToEdit);
    }
}
