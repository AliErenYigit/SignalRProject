﻿using Microsoft.EntityFrameworkCore;
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
    public class EfBasketDal:GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContext context):base(context) { }

        public List<Basket> GetBasketByMenuTableNumber(int id)
        {
            using var context = new SignalRContext();   
            var values=context.Baskets.Where(x=>x.MenuTableID==id).Include(y=>y.Product).ToList();
            return values;
        }
    }
}
