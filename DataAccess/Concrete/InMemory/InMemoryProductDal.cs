﻿using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Product{ProductId=1,CategoryId=1,ProductName="Masa",UnitPrice=25,UniteInStock=4},
                new Product{ProductId=3,CategoryId=3,ProductName="sad",UnitPrice=25,UniteInStock=4},
                new Product{ProductId=2,CategoryId=4,ProductName="klavye",UnitPrice=25,UniteInStock=4},
                new Product{ProductId=4,CategoryId=1,ProductName="bilgisayar",UnitPrice=25,UniteInStock=4},
                new Product{ProductId=5,CategoryId=3,ProductName="mouse",UnitPrice=25,UniteInStock=4},
                new Product{ProductId=6,CategoryId=2,ProductName="lamba",UnitPrice=25,UniteInStock=4},


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

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
          return  _products.Where(p => p.CategoryId==categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim Ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UniteInStock = product.UniteInStock;
        }
    }
}