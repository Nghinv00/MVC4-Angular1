using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeduShop.Data;
using TeduShop.Model;


namespace TeduShop.Service
{
    public class TagService
    {
        public ShopOnlineEntities Connect_Enttity = new ShopOnlineEntities();
        public IList<TagModel> GetAll()
        {

            IList<TagModel> result = new List<TagModel>();
            result = Connect_Enttity.Tags.Select(x => new TagModel
            {
                ID = x.ID,
                Name = x.Name,
                Type = x.Type

            }).ToList();

            return result;
        }
        public IList<TagModel> GetAllPage(int page, int pageSize)
        {

            IList<TagModel> result = new List<TagModel>();
            result = Connect_Enttity.Tags.Select(x => new TagModel
            {
                ID = x.ID,
                Name = x.Name,
                Type = x.Type

            }).OrderByDescending(x => x.Name).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return result;
        }

        public IList<TagModel> GetId(string ID)
        {
            IList<TagModel> result = new List<TagModel>();

            result = Connect_Enttity.Tags.Where(x => x.ID == ID).Select(x => new TagModel
            {
                ID = x.ID,
                Name = x.Name,
                Type = x.Type

            }).ToList();

            return result;
        }

        public IEnumerable<TagModel> Read()
        {
            return GetAll();
        }
        public IEnumerable<TagModel> ReadPage(int page, int pageSize)
        {
            return GetAllPage(page, pageSize);
        }
        public IEnumerable<TagModel> ReadID(string ID)
        {
            return GetId(ID);
        }
        public void Deleteone(string Id)
        {

            var data = (from c in Connect_Enttity.Tags where c.ID == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Tags.Remove(data);
                Connect_Enttity.SaveChanges();
                Dispose();
            }

        }

        public void DeleteAll(string[] Id)
        {
            if (Id != null)
            {
                foreach (var i in Id)
                {
                    var data = Connect_Enttity.Tags.FirstOrDefault(x => x.ID.Equals(i));
                    Connect_Enttity.Tags.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(TagModel model)
        {
            var data = Connect_Enttity.Tags.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                var entity = new Tag();
                entity.ID = model.ID;
                entity.Name = model.Name;
                entity.Type = model.Type;

                Connect_Enttity.Tags.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(TagModel model)
        {
            var data = Connect_Enttity.Tags.FirstOrDefault(x => x.ID == model.ID);
            if (data != null)
            {
                data.ID = model.ID;
                data.Name = model.Name;
                data.Type = model.Type;

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
