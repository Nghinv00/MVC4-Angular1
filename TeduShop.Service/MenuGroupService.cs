using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeduShop.Data;
using TeduShop.Model;

namespace TeduShop.Service
{
    public class MenuGroupService
    {
        public ShopOnlineEntities Connect_Enttity = new ShopOnlineEntities();
        public IList<MenuGroupModel> GetAll()
        {

            IList<MenuGroupModel> result = new List<MenuGroupModel>();
            result = Connect_Enttity.MenuGroups.Select(x => new MenuGroupModel
            {
                ID = x.ID,
                Name = x.Name
                
            }).ToList();

            return result;
        }
        public IList<MenuGroupModel> GetAllPage(int page, int pageSize)
        {

            IList<MenuGroupModel> result = new List<MenuGroupModel>();
            result = Connect_Enttity.MenuGroups.Select(x => new MenuGroupModel
            {
                ID = x.ID,
                Name = x.Name

            }).OrderByDescending(x => x.Name).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return result;
        }

        public IList<MenuGroupModel> GetId(int ID)
        {
            IList<MenuGroupModel> result = new List<MenuGroupModel>();

            result = Connect_Enttity.MenuGroups.Where(x => x.ID == ID).Select(x => new MenuGroupModel
            {
                ID = x.ID,
                Name = x.Name

            }).ToList();

            return result;
        }

        public IEnumerable<MenuGroupModel> Read()
        {
            return GetAll();
        }
        public IEnumerable<MenuGroupModel> ReadPage(int page, int pageSize)
        {
            return GetAllPage(page, pageSize);
        }
        public IEnumerable<MenuGroupModel> ReadID(int ID)
        {
            return GetId(ID);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.MenuGroups where c.ID == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.MenuGroups.Remove(data);
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
                    var data = Connect_Enttity.MenuGroups.FirstOrDefault(x => x.ID.Equals(i));
                    Connect_Enttity.MenuGroups.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(MenuGroupModel model)
        {
            var data = Connect_Enttity.MenuGroups.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                var entity = new MenuGroup();
                entity.Name = model.Name;
                
                Connect_Enttity.MenuGroups.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(MenuGroupModel model)
        {
            var data = Connect_Enttity.MenuGroups.FirstOrDefault(x => x.ID == model.ID);
            if (data != null)
            {
                data.Name = model.Name;
                
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
