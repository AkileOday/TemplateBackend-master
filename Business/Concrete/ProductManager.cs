using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public IResult Add(Product product)
		{
			//is kurallari yazilir
			
			if(product.CategoryId==1)
			{
				
				return new ErrorResult("Bu katagoriye urun kabul edilmiyor");
			}
			else 
			{
				_productDal.Add(product);
				return new SuccessResult("Urun eklendi");
			}
		}

		public IDataResult<List<Product>> GelAllByCategory(int categoryId)
		{
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==categoryId), "urunler listelendi");
		}

		public IDataResult<List<Product>> GetAll()
		{
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(),"urunler listelendi");
		}
	}
}
