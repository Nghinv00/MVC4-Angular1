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
    public class PostCategoryService
    {
        public ShopOnlineEntities Connect_Enttity = new ShopOnlineEntities();

        public IList<PostCategoryModel> GetAll()
        {
            IList<PostCategoryModel> result = new List<PostCategoryModel>();

            result = Connect_Enttity.PostCategories.Select(x => new PostCategoryModel
            {
                ID = x.ID,
                Name = x.Name,
                Alias = x.Alias,
                Description = x.Description,
                parentID = x.parentID,
                DisplayOrder = x.DisplayOrder,
                Image = x.Image,
                MetaKeyword = x.MetaKeyword,
                MetaDescription = x.MetaDescription,
                CreateDate = (DateTime)(x.CreateDate),
                CreateBy = x.CreateBy,
                UpdatedDate = (DateTime)(x.UpdatedDate),
                UpdatedBy = (x.UpdatedBy),
                Status = x.Status,
                HomeFlag = x.HomeFlag

            }).ToList();

            return result;
        }
        public IList<PostCategoryModel> GetAllPage(int page, int pageSize)
        {
            IList<PostCategoryModel> result = new List<PostCategoryModel>();

            result = Connect_Enttity.PostCategories.Select(x => new PostCategoryModel
            {
                ID = x.ID,
                Name = x.Name,
                Alias = x.Alias,
                Description = x.Description,
                parentID = x.parentID,
                DisplayOrder = x.DisplayOrder,
                Image = x.Image,
                MetaKeyword = x.MetaKeyword,
                MetaDescription = x.MetaDescription,
                CreateDate = (DateTime)(x.CreateDate),
                CreateBy = x.CreateBy,
                UpdatedDate = (DateTime)(x.UpdatedDate),
                UpdatedBy = (x.UpdatedBy),
                Status = x.Status,
                HomeFlag = x.HomeFlag

            }).OrderByDescending(x => x.CreateDate).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return result;
        }

        public IList<PostCategoryModel> GetId(int id)
        {
            IList<PostCategoryModel> result = new List<PostCategoryModel>();

            result = Connect_Enttity.PostCategories.Where(x => x.ID == id).Select(x => new PostCategoryModel
            {
                ID = x.ID,
                Name = x.Name,
                Alias = x.Alias,
                Description = x.Description,
                parentID = x.parentID,
                DisplayOrder = x.DisplayOrder,
                Image = x.Image,
                MetaKeyword = x.MetaKeyword,
                MetaDescription = x.MetaDescription,
                CreateDate = (DateTime)(x.CreateDate),
                CreateBy = x.CreateBy,
                UpdatedDate = (DateTime)(x.UpdatedDate),
                UpdatedBy = (x.UpdatedBy),
                Status = x.Status,
                HomeFlag = x.HomeFlag

            }).ToList();

            return result;
        }

        public IEnumerable<PostCategoryModel> ReadPage(int page, int pageSize)
        {
            return GetAllPage(page,pageSize);
        }
        public IEnumerable<PostCategoryModel> Read()
        {
            return GetAll();
        }
        public IEnumerable<PostCategoryModel> ReadID(int id)
        {
            return GetId(id);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.PostCategories where c.ID == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.PostCategories.Remove(data);
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
                    var data = Connect_Enttity.PostCategories.FirstOrDefault(x => x.ID.Equals(i));
                    Connect_Enttity.PostCategories.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(PostCategoryModel model)
        {
            var data = Connect_Enttity.PostCategories.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                var entity = new PostCategory();
                entity.Name = model.Name;
                entity.Alias = model.Alias;
                entity.Description = model.Description;
                entity.parentID = model.parentID;
                entity.DisplayOrder = model.DisplayOrder;
                entity.Image = model.Image;
                entity.MetaKeyword = model.MetaKeyword;
                entity.MetaDescription = model.MetaDescription;
                entity.CreateDate = model.CreateDate;
                entity.CreateBy = model.CreateBy;
                entity.UpdatedDate = model.UpdatedDate;
                entity.UpdatedBy = model.UpdatedBy;
                entity.Status = model.Status;
                entity.HomeFlag = model.HomeFlag;

                Connect_Enttity.PostCategories.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(PostCategoryModel model)
        {
            var data = Connect_Enttity.PostCategories.FirstOrDefault(x => x.ID == model.ID);
            if (data != null)
            {
                data.Name = model.Name;
                data.Alias = model.Alias;
                data.Description = model.Description;
                data.parentID = model.parentID;
                data.DisplayOrder = model.DisplayOrder;
                data.Image = model.Image;
                data.MetaKeyword = model.MetaKeyword;
                data.MetaDescription = model.MetaDescription;
                data.CreateDate = model.CreateDate;
                data.CreateBy = model.CreateBy;
                data.UpdatedDate = model.UpdatedDate;
                data.UpdatedBy = model.UpdatedBy;
                data.Status = model.Status;
                data.HomeFlag = model.HomeFlag;

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
