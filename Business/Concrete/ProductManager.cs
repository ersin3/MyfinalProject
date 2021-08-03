using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResults add(Product product)
        {

           ValidationTool.Validate(new ProductValidator(),product);
            //loglama
            //cacheremove
            //performance
            //transaction
            //yetkilendirme

            //business code
            
            _productDal.Add(product); 

            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAllByCategory(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId==productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetail()
        {
           
            return new SuccessDataResult < List < ProductDetailDto >>(_productDal.GetProductDetail());
        }

        public IDataResult<List<Product>> GettAll()
        {
            if (DateTime.Now.Hour==20)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            //İş Kodları
            // if(Yetkisi var mı similasyon yap)
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }
    }
}
