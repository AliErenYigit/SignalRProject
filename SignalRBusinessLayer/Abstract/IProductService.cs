using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        List<Product> TTGetProductWithCategories();
        public int TProductCount();

		int TProductByCategoryNameHamburger();
		int TProductByCategoryNameDrink();
		decimal TProductPriceAvg();
		string TProductNameByMaxPrice();
		string TProductNameByMinPrice();

		decimal TProductAvgPriceByHamburger();
		List<Product> TGetLast9Products();
	}

}
