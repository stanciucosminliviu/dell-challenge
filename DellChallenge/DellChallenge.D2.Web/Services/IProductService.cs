﻿using DellChallenge.D2.Web.Models;
using System.Collections.Generic;

namespace DellChallenge.D2.Web.Services
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAll();
        ProductModel Add(NewProductModel newProduct);
        string Delete(string id);
        ProductModel Get(string id);
        void Edit(ProductModel productToEdit);
    }
}