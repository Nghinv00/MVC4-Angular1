using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeduShop.Data;
using TeduShop.Model;

namespace TeduShop.Service
{
    public class ProductTagService
    {
        public ShopOnlineEntities Connect_Enttity = new ShopOnlineEntities();
        public IList<ProductTagModel> GetAll()
        {

            IList<ProductTagModel> result = new List<ProductTagModel>();
            result = Connect_Enttity.ProductTags.Select(x => new ProductTagModel
            {
                ID = x.ID,
                productID = x.productID,
                TagID = x.TagID

            }).ToList();

            return result;
        }
        public IList<ProductTagModel> GetAllPage(int page, int pageSize)
        {

            IList<ProductTagModel> result = new List<ProductTagModel>();
            result = Connect_Enttity.ProductTags.Select(x => new ProductTagModel
            {
                ID = x.ID,
                productID = x.productID,
                TagID = x.TagID

            }).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return result;
        }

        public IList<ProductTagModel> GetId(int ID)
        {
            IList<ProductTagModel> result = new List<ProductTagModel>();

            result = Connect_Enttity.ProductTags.Where(x => x.ID == ID).Select(x => new ProductTagModel
            {
                ID = x.ID,
                productID = x.productID,
                TagID = x.TagID

            }).ToList();

            return result;
        }

        public IEnumerable<ProductTagModel> Read()
        {
            return GetAll();
        }
        public IEnumerable<ProductTagModel> ReadPage(int page, int pageSize)
        {
            return GetAllPage(page, pageSize);
        }
        public IEnumerable<ProductTagModel> ReadID(int ID)
        {
            return GetId(ID);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.ProductTags where c.ID == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.ProductTags.Remove(data);
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
                    var data = Connect_Enttity.ProductTags.FirstOrDefault(x => x.ID.Equals(i));
                    Connect_Enttity.ProductTags.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(ProductTagModel model)
        {
            var data = Connect_Enttity.ProductTags.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                var entity = new ProductTag();
                entity.productID = model.productID;
                entity.TagID = model.TagID;

                Connect_Enttity.ProductTags.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(ProductTagModel model)
        {
            var data = Connect_Enttity.ProductTags.FirstOrDefault(x => x.ID == model.ID);
            if (data != null)
            {
                data.productID = model.productID;
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
