using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.EntityFrameWork
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }

		public int ActiveCategoryCount()
		{
			using var context=new SignalRContext();
			return context.Categories.Where(x=>x.Status==true).Count();
		}

		public int CategoryCount()
		{
			using var context = new SignalRContext();
			return context.Categories.Count();
		}

		public int PasiveCategoryCount()
		{
			using var context = new SignalRContext();
			return context.Categories.Where(x => x.Status == false).Count();
		}
	}
}
