using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Concrete
{
	public class MenuTableManager : IMenuTableService
	{
		private readonly IMenuTabledal _menuTabledal;

		public MenuTableManager(IMenuTabledal menuTabledal)
		{
			_menuTabledal = menuTabledal;
		}

		public void TAdd(MenuTable entity)
		{
			_menuTabledal.Add(entity);
		}

		public void TDelete(MenuTable entity)
		{
			_menuTabledal.Delete(entity);
		}

		public MenuTable TGetByID(int id)
		{
			return _menuTabledal.GetByID(id);
		}

		public List<MenuTable> TGetListAll()
		{
			return _menuTabledal.GetListAll();
		}

		public int TMenuTableCount()
		{
			return _menuTabledal.MenuTableCount();
		}

		public void TUpdate(MenuTable entity)
		{
			_menuTabledal.Update(entity);
		}
	}
}
