using Microsoft.EntityFrameworkCore;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.EntityFrameWork
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductWithCategories()
        {
            var context=new SignalRContext();
            var values=context.Products.Include(x=>x.Category).ToList();
            return values;
        }

		public int ProductByCategoryNameDrink()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryID).FirstOrDefault())).Count();

		}
		public int ProductByCategoryNameHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Count();
		}

		public int ProductCount()
		{
			using var context=new SignalRContext(); 
            return context.Products.Count();
		}

		public string ProductNameByMaxPrice()
		{
			using var contex=new SignalRContext();
			return contex.Products.Where(x => x.Price == (contex.Products.Max(y => y.Price))).Select(z=>z.ProductName).FirstOrDefault();
		}

		public string ProductNameByMinPrice()
		{
			using var contex = new SignalRContext();
			return contex.Products.Where(x => x.Price == (contex.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
		}

		public decimal ProductPriceAvg()
		{
			using var context= new SignalRContext();
			return context.Products.Average(x => x.Price);
		}

		public decimal ProductAvgPriceByHamburger()
		{
			 using var context=new SignalRContext();

			return context.Products.Where(x=>x.CategoryID==(context.Categories.Where(y=>y.CategoryName=="Hamburger").Select(z=>z.CategoryID).FirstOrDefault())).Average(w=>w.Price);
		}

		public List<Product> GetLast9Products()
		{
			var context = new SignalRContext();
			var values = context.Products.Take(9).ToList();
			return values;
		}
	}
}
