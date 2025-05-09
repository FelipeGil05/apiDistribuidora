﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Dtos;

namespace Application.Interfaces
{
    public interface IProductService
    {
        public Product? GetProductById(int id);
        public List<Product> GetProducts();
        public int AddProduct(ProductDto productDto);
        public void UpdateProduct(int id, ProductDto productDto);
        public void DeletePoduct(int id);
    }
}
