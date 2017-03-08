using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeduShop.Data;
using TeduShop.Model;


namespace TeduShop.Service
{
    public class FooterService
    {
        public ShopOnlineEntities Connect_Enttity = new ShopOnlineEntities();
        public IList<FooterModel> GetAll()
        {

            IList<FooterModel> result = new List<FooterModel>();
            result = Connect_Enttity.Footers.Select(x => new FooterModel
            {
                ID = x.ID,
                Content = x.Content

            }).ToList();

            return result;
        }
        public IList<FooterModel> GetAllPage(int page, int pageSize)
        {

            IList<FooterModel> result = new List<FooterModel>();
            result = Connect_Enttity.Footers.Select(x => new FooterModel
            {
                ID = x.ID,
                Content = x.Content

            }).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return result;
        }

        public IList<FooterModel> GetId(byte[] ID)
        {
            IList<FooterModel> result = new List<FooterModel>();

            result = Connect_Enttity.Footers.Where(x => x.ID == ID).Select(x => new FooterModel
            {
                ID = x.ID,
                Content = x.Content

            }).ToList();

            return result;
        }

        public IEnumerable<FooterModel> Read()
        {
            return GetAll();
        }
        public IEnumerable<FooterModel> ReadPage(int page, int pageSize)
        {
            return GetAllPage(page, pageSize);
        }
        public IEnumerable<FooterModel> ReadID(byte[] ID)
        {
            return GetId(ID);
        }
        public void Deleteone(byte[] Id)
        {

            var data = (from c in Connect_Enttity.Footers where c.ID == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Footers.Remove(data);
                Connect_Enttity.SaveChanges();
                Dispose();
            }

        }

        public void DeleteAll(byte[] Id)
        {
            if (Id != null)
            {
                foreach (var i in Id)
                {
                    var data = Connect_Enttity.Footers.FirstOrDefault(x => x.ID.Equals(i));
                    Connect_Enttity.Footers.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(FooterModel model)
        {
            var data = Connect_Enttity.Footers.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                var entity = new Footer();
                entity.ID = model.ID;
                entity.Content = model.Content;

                Connect_Enttity.Footers.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(FooterModel model)
        {
            var data = Connect_Enttity.Footers.FirstOrDefault(x => x.ID == model.ID);
            if (data != null)
            {
                data.ID = model.ID;
                data.Content = model.Content;

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
