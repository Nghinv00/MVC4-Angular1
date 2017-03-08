using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeduShop.Data;
using TeduShop.Model;


namespace TeduShop.Service
{
    public class MenuService
    {
        public ShopOnlineEntities Connect_Enttity = new ShopOnlineEntities();
        public IList<MenuModel> GetAll()
        {

            IList<MenuModel> result = new List<MenuModel>();
            result = Connect_Enttity.Menus.Select(x => new MenuModel
            {
                ID = x.ID,
                Name = x.Name,
                URL = x.URL,
                DisplayOrder = x.DisplayOrder,
                Target = x.Target,
                Status = x.Status,
                GroupID = x.GroupID

            }).ToList();

            return result;
        }
        public IList<MenuModel> GetAllPage(int page, int pageSize)
        {

            IList<MenuModel> result = new List<MenuModel>();
            result = Connect_Enttity.Menus.Select(x => new MenuModel
            {
                ID = x.ID,
                Name = x.Name,
                URL = x.URL,
                DisplayOrder = x.DisplayOrder,
                Target = x.Target,
                Status = x.Status,
                GroupID = x.GroupID

            }).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return result;
        }

        public IList<MenuModel> GetId(int ID)
        {
            IList<MenuModel> result = new List<MenuModel>();

            result = Connect_Enttity.Menus.Where(x => x.ID == ID).Select(x => new MenuModel
            {
                ID = x.ID,
                Name = x.Name,
                URL = x.URL,
                DisplayOrder = x.DisplayOrder,
                Target = x.Target,
                Status = x.Status,
                GroupID = x.GroupID

            }).ToList();

            return result;
        }
        public IEnumerable<MenuModel> ReadPage(int page, int pageSize)
        {
            return GetAllPage(page, pageSize);
        }
        public IEnumerable<MenuModel> Read()
        {
            return GetAll();
        }
        public IEnumerable<MenuModel> ReadID(int ID)
        {
            return GetId(ID);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Menus where c.ID == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Menus.Remove(data);
                Connect_Enttity.SaveChanges();
                Dispose();
            }

        }

        public void DeleteAll(int[] Id)
        {
            if (Id != null)
            {
                foreach (var i in Id)
                {
                    var data = Connect_Enttity.Menus.FirstOrDefault(x => x.ID.Equals(i));
                    Connect_Enttity.Menus.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(MenuModel model)
        {
            var data = Connect_Enttity.Menus.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                var entity = new Menu();
                entity.Name = model.Name;
                entity.URL = model.URL;
                entity.DisplayOrder = model.DisplayOrder;
                entity.Target = model.Target;
                entity.Status = model.Status;
                entity.GroupID = model.GroupID;

                Connect_Enttity.Menus.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(MenuModel model)
        {
            var data = Connect_Enttity.Menus.FirstOrDefault(x => x.ID == model.ID);
            if (data != null)
            {
                data.Name = model.Name;
                data.URL = model.URL;
                data.DisplayOrder = model.DisplayOrder;
                data.Target = model.Target;
                data.Status = model.Status;
                data.GroupID = model.GroupID;

                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Dispose()
        {
            Connect_Enttity.Dispose();
        }
    }
}
