﻿using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //oracledan çekicem,Postgres,MongoDb 
            _products = new List<Product> {
                new Product{ProductId=1,CategoryId=1,ProductName="Masa",UnitPrice=25},
                new Product{ProductId=3,CategoryId=3,ProductName="sad",UnitPrice=25},
                new Product{ProductId=2,CategoryId=4,ProductName="klavye",UnitPrice=25},
                new Product{ProductId=4,CategoryId=1,ProductName="bilgisayar",UnitPrice=25},
                new Product{ProductId=5,CategoryId=3,ProductName="mouse",UnitPrice=25},
                new Product{ProductId=6,CategoryId=2,ProductName="lamba",UnitPrice=25},


            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query 
            //Lambda
            Product  productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
          return  _products.Where(p => p.CategoryId==categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gönderdiğim Ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            
        }
    }
}
