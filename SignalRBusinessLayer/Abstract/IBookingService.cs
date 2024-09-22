﻿using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Abstract
{
    public interface IBookingService:IGenericService<Booking>
    {
		void TBookingStatusApproved(int id);
		void TBookingStatusCancelled(int id);
	}
}