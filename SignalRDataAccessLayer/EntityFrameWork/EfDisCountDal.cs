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
    public class EfDisCountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDisCountDal(SignalRContext context) : base(context)
        {
        }

		public void ChangeStatusToFalse(int id)
		{
			using var context = new SignalRContext();
			var values = context.Discounts.Find(id);
			values.Status = false;
			context.SaveChanges();
		}

		public void ChangeStatusToTrue(int id)
		{
			using var context = new SignalRContext();
			var values = context.Discounts.Find(id);
			values.Status = true;
			context.SaveChanges();
		}

		public List<Discount> GetListByStatusTrue()
		{
			using var contex=new SignalRContext();
			var value=contex.Discounts.Where(x=>x.Status == true).ToList(); 
			return(value);
		}
	}
}
