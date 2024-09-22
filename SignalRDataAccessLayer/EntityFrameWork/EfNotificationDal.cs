﻿using SignalRDataAccessLayer.Abstract;
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
	public class EfNotificationDal:GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(SignalRContext context) : base(context)
		{
	
		}

		public List<Notification> GetAllNotificationsByFalse()
		{
			using var context = new SignalRContext();
			return context.Notifications.Where(x=>x.Status==false).ToList();
		}

		public int NotificationCountByStatusFalse()
		{
			using var context = new SignalRContext();
			return context.Notifications.Where(x=>x.Status==false).Count();
		}

		public void NotificationStatusChangeToFalse(int id)
		{
			using var context = new SignalRContext();
			var value = context.Notifications.Find(id);
			value.Status = false;
			context.SaveChanges();
		}

		public void NotificationStatusChangeToTrue(int id)
		{
			using var context= new SignalRContext();
			var value = context.Notifications.Find(id);
			value.Status=true;
			context.SaveChanges();
		}
	}
}