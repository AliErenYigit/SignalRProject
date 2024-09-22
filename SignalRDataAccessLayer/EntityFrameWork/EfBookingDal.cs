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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

		public void BookingStatusApproved(int id)
		{
			using var contex = new SignalRContext();
			var values = contex.Bookings.Find(id);
			values.Description = "Rezervasyon Onaylandı";
			contex.SaveChanges();
		}

		public void BookingStatusCancelled(int id)
		{
			using var contex = new SignalRContext();
			var values = contex.Bookings.Find(id);
			values.Description = "Rezervasyon İptal Edildi";
			contex.SaveChanges();
		}
	}
}
