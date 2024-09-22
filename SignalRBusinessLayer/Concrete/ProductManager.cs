﻿using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Migrations;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

		public int TProductByCategoryNameDrink()
		{
			return _productDal.ProductByCategoryNameDrink();
		}

		public int TProductByCategoryNameHamburger()
		{
			return _productDal.ProductByCategoryNameHamburger();
		}

		public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product TGetByID(int id)
        {
            return _productDal.GetByID(id);      
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

		public int TProductCount()
		{
			return _productDal.ProductCount();
		}

		public List<Product> TTGetProductWithCategories()
        {
            return _productDal.GetProductWithCategories();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

		public decimal TProductPriceAvg()
		{
			return _productDal.ProductPriceAvg();
		}

		public string TProductNameByMaxPrice()
		{
            return _productDal.ProductNameByMaxPrice();
		}

		public string TProductNameByMinPrice()
		{
			return _productDal.ProductNameByMinPrice();
		}

		public decimal TProductAvgPriceByHamburger()
		{
			return _productDal.ProductAvgPriceByHamburger();
		}

		public List<Product> TGetLast9Products()
		{
			return _productDal.GetLast9Products();
		}
	}
}