using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeduShop.Data;
using TeduShop.Model;


namespace TeduShop.Service
{
    public class SupportOnlineService
    {
        public ShopOnlineEntities Connect_Enttity = new ShopOnlineEntities();
        public IList<SupportOnlineModel> GetAll()
        {

            IList<SupportOnlineModel> result = new List<SupportOnlineModel>();
            result = Connect_Enttity.SupportOnlines.Select(x => new SupportOnlineModel
            {
                ID = x.ID,
                Name = x.Name,
                Department = x.Department,
                Skype = x.Skype,
                Mobile = x.Mobile,
                Email = x.Email,
                Yahoo = x.Yahoo,
                Facebook = x.Facebook,
                Status = (bool)(x.Status),
                DisplayOrder = x.DisplayOrder

            }).ToList();

            return result;
        }
        public IList<SupportOnlineModel> GetAllPage(int page, int pageSize)
        {

            IList<SupportOnlineModel> result = new List<SupportOnlineModel>();
            result = Connect_Enttity.SupportOnlines.Select(x => new SupportOnlineModel
            {
                ID = x.ID,
                Name = x.Name,
                Department = x.Department,
                Skype = x.Skype,
                Mobile = x.Mobile,
                Email = x.Email,
                Yahoo = x.Yahoo,
                Facebook = x.Facebook,
                Status = (bool)(x.Status),
                DisplayOrder = x.DisplayOrder

            }).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return result;
        }

        public IList<SupportOnlineModel> GetId(int ID)
        {
            IList<SupportOnlineModel> result = new List<SupportOnlineModel>();

            result = Connect_Enttity.SupportOnlines.Where(x => x.ID == ID).Select(x => new SupportOnlineModel
            {
                ID = x.ID,
                Name = x.Name,
                Department = x.Department,
                Skype = x.Skype,
                Mobile = x.Mobile,
                Email = x.Email,
                Yahoo = x.Yahoo,
                Facebook = x.Facebook,
                Status = (bool)(x.Status),
                DisplayOrder = x.DisplayOrder

            }).ToList();

            return result;
        }
        public IEnumerable<SupportOnlineModel> ReadPage(int page, int pageSize)
        {
            return GetAllPage(page, pageSize);
        }
        public IEnumerable<SupportOnlineModel> Read()
        {
            return GetAll();
        }
        public IEnumerable<SupportOnlineModel> ReadID(int ID)
        {
            return GetId(ID);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.SupportOnlines where c.ID == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.SupportOnlines.Remove(data);
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
                    var data = Connect_Enttity.SupportOnlines.FirstOrDefault(x => x.ID.Equals(i));
                    Connect_Enttity.SupportOnlines.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(SupportOnlineModel model)
        {
            var data = Connect_Enttity.SupportOnlines.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                var entity = new SupportOnline();
                entity.Name = model.Name;
                entity.Department = model.Department;
                entity.Skype = model.Skype;
                entity.Mobile = model.Mobile;
                entity.Email = model.Email;
                entity.Yahoo = model.Yahoo;
                entity.Facebook = model.Facebook;
                entity.Status = model.Status;
                entity.DisplayOrder = Convert.ToInt32(model.DisplayOrder);

                Connect_Enttity.SupportOnlines.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(SupportOnlineModel model)
        {
            var data = Connect_Enttity.SupportOnlines.FirstOrDefault(x => x.ID == model.ID);
            if (data != null)
            {
                data.Name = model.Name;
                data.Department = model.Department;
                data.Skype = model.Skype;
                data.Mobile = model.Mobile;
                data.Email = model.Email;
                data.Yahoo = model.Yahoo;
                data.Facebook = model.Facebook;
                data.Status = model.Status;
                data.DisplayOrder = Convert.ToInt32(model.DisplayOrder);

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
