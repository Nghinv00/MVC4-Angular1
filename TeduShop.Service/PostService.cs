using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using TeduShop.Data;
using TeduShop.Model;

namespace TeduShop.Service
{
    public class PostService
    {
        public ShopOnlineEntities Connect_Enttity = new ShopOnlineEntities();

        public IList<PostModel> GetAll()
        {
            IList<PostModel> result = new List<PostModel>();

            result = Connect_Enttity.Posts.Select(x => new PostModel
            {
                ID = x.ID,
                Name = x.Name,
                Alias = x.Alias,
                CategoryID = x.CategoryID,
                Image = x.Image,
                Description = x.Description,
                Content = x.Content,
                MetaKeyword = x.MetaKeyword,
                MetaDescription = x.MetaDescription,
                CreateDate = (DateTime)(x.CreateDate),
                CreateBy = x.CreateBy,
                UpdatedDate = (DateTime)(x.UpdatedDate),
                UpdatedBy = (x.UpdatedBy),
                Status = x.Status,
                HomeFlag = x.HomeFlag,
                HotFlag = x.HotFlag,
                ViewCount = x.ViewCount

            }).ToList();

            return result;
        }
        public IList<PostModel> GetAllPage(string search,  int page, int pageSize)
        {
            IList<PostModel> result = new List<PostModel>();

            result = Connect_Enttity.Posts.Select(x => new PostModel
            {
                ID = x.ID,
                Name = x.Name,
                Alias = x.Alias,
                CategoryID = x.CategoryID,
                Image = x.Image,
                Description = x.Description,
                Content = x.Content,
                MetaKeyword = x.MetaKeyword,
                MetaDescription = x.MetaDescription,
                CreateDate = (DateTime)(x.CreateDate),
                CreateBy = x.CreateBy,
                UpdatedDate = (DateTime)(x.UpdatedDate),
                UpdatedBy = (x.UpdatedBy),
                Status = x.Status,
                HomeFlag = x.HomeFlag,
                HotFlag = x.HotFlag,
                ViewCount = x.ViewCount

            }).Where(x => x.Name.Contains(search)).OrderByDescending(x => x.CreateDate).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return result;
        }

        public IList<PostModel> GetId(int id)
        {
            IList<PostModel> result = new List<PostModel>();

            result = Connect_Enttity.Posts.Where(x => x.ID == id).Select(x => new PostModel
            {
                ID = x.ID,
                Name = x.Name,
                Alias = x.Alias,
                CategoryID = x.CategoryID,
                Image = x.Image,
                Description = x.Description,
                Content = x.Content,
                MetaKeyword = x.MetaKeyword,
                MetaDescription = x.MetaDescription,
                CreateDate = (DateTime)(x.CreateDate),
                CreateBy = x.CreateBy,
                UpdatedDate = (DateTime)(x.UpdatedDate),
                UpdatedBy = (x.UpdatedBy),
                Status = x.Status,
                HomeFlag = x.HomeFlag,
                HotFlag = x.HotFlag,
                ViewCount = x.ViewCount

            }).ToList();

            return result;
        }

        public IEnumerable<PostModel> ReadPage(string search,int page, int pageSize)
        {
            return GetAllPage(search,page, pageSize);
        }
        public IEnumerable<PostModel> Read()
        {
            return GetAll();
        }
        public IEnumerable<PostModel> ReadID(int id)
        {
            return GetId(id);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Posts where c.ID == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Posts.Remove(data);
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
                    var data = Connect_Enttity.Posts.FirstOrDefault(x => x.ID.Equals(i));
                    Connect_Enttity.Posts.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(PostModel model)
        {
            var data = Connect_Enttity.Posts.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                var entity = new Post();
                entity.Name = model.Name;
                entity.Alias = model.Alias;
                entity.CategoryID = model.CategoryID;
                entity.Image = model.Image;
                entity.Description = model.Description;
                entity.Content = model.Content;
                entity.MetaKeyword = model.MetaKeyword;
                entity.MetaDescription = model.MetaDescription;
                entity.CreateDate = model.CreateDate;
                entity.CreateBy = model.CreateBy;
                entity.UpdatedDate = model.UpdatedDate;
                entity.UpdatedBy = model.UpdatedBy;
                entity.Status = model.Status;
                entity.HomeFlag = model.HomeFlag;
                entity.HotFlag = model.HotFlag;
                entity.ViewCount = model.ViewCount;

                Connect_Enttity.Posts.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(PostModel model)
        {
            var data = Connect_Enttity.Posts.FirstOrDefault(x => x.ID == model.ID);
            if (data != null)
            {
                data.Name = model.Name;
                data.Alias = model.Alias;
                data.CategoryID = model.CategoryID;
                data.Image = model.Image;
                data.Description = model.Description;
                data.Content = model.Content;
                data.MetaKeyword = model.MetaKeyword;
                data.MetaDescription = model.MetaDescription;
                data.CreateDate = model.CreateDate;
                data.CreateBy = model.CreateBy;
                data.UpdatedDate = model.UpdatedDate;
                data.UpdatedBy = model.UpdatedBy;
                data.Status = model.Status;
                data.HomeFlag = model.HomeFlag;
                data.HotFlag = model.HotFlag;
                data.ViewCount = model.ViewCount;

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
