using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeduShop.Data;
using TeduShop.Model;

namespace TeduShop.Service
{
    public class PostTagService
    {
        public ShopOnlineEntities Connect_Enttity = new ShopOnlineEntities();
        public IList<PostTagModel> GetAll()
        {

            IList<PostTagModel> result = new List<PostTagModel>();
            result = Connect_Enttity.PostTags.Select(x => new PostTagModel
            {
                ID = x.ID,
                PostID = x.PostID,
                TagID = x.TagID

            }).ToList();

            return result;
        }
        public IList<PostTagModel> GetAllPage(int page, int pageSize)
        {

            IList<PostTagModel> result = new List<PostTagModel>();
            result = Connect_Enttity.PostTags.Select(x => new PostTagModel
            {
                ID = x.ID,
                PostID = x.PostID,
                TagID = x.TagID

            }).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return result;
        }

        public IList<PostTagModel> GetId(int ID)
        {
            IList<PostTagModel> result = new List<PostTagModel>();

            result = Connect_Enttity.PostTags.Where(x => x.ID == ID).Select(x => new PostTagModel
            {
                ID = x.ID,
                PostID = x.PostID,
                TagID = x.TagID

            }).ToList();

            return result;
        }

        public IEnumerable<PostTagModel> Read()
        {
            return GetAll();
        }
        public IEnumerable<PostTagModel> ReadPage(int page, int pageSize)
        {
            return GetAllPage(page, pageSize);
        }
        public IEnumerable<PostTagModel> ReadID(int ID)
        {
            return GetId(ID);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.PostTags where c.ID == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.PostTags.Remove(data);
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
                    var data = Connect_Enttity.PostTags.FirstOrDefault(x => x.ID.Equals(i));
                    Connect_Enttity.PostTags.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(PostTagModel model)
        {
            var data = Connect_Enttity.PostTags.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                var entity = new PostTag();
                entity.PostID = model.PostID;
                entity.TagID = model.TagID;

                Connect_Enttity.PostTags.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(PostTagModel model)
        {
            var data = Connect_Enttity.PostTags.FirstOrDefault(x => x.ID == model.ID);
            if (data != null)
            {
                data.PostID = model.PostID;
                data.TagID = model.TagID;

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
