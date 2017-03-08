using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeduShop.Data;
using TeduShop.Model;


namespace TeduShop.Service
{
    public class SlideService
    {
        public ShopOnlineEntities Connect_Enttity = new ShopOnlineEntities();
        public IList<SlideModel> GetAll()
        {

            IList<SlideModel> result = new List<SlideModel>();
            result = Connect_Enttity.Slides.Select(x => new SlideModel
            {
                ID = x.ID,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image,
                Url = x.URL,
                DisplayOrder = x.DisplayOrder,
                Status = x.Status,
                Content= x.Content

            }).ToList();

            return result;
        }
        public IList<SlideModel> GetAllPage(int page, int pageSize)
        {

            IList<SlideModel> result = new List<SlideModel>();
            result = Connect_Enttity.Slides.Select(x => new SlideModel
            {
                ID = x.ID,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image,
                Url = x.URL,
                DisplayOrder = x.DisplayOrder,
                Status = x.Status,
                Content = x.Content

            }).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return result;
        }

        public IList<SlideModel> GetId(int ID)
        {
            IList<SlideModel> result = new List<SlideModel>();

            result = Connect_Enttity.Slides.Where(x => x.ID == ID).Select(x => new SlideModel
            {
                ID = x.ID,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image,
                Url = x.URL,
                DisplayOrder = x.DisplayOrder,
                Status = x.Status,
                Content = x.Content

            }).ToList();

            return result;
        }
        public IEnumerable<SlideModel> ReadPage(int page, int pageSize)
        {
            return GetAllPage(page, pageSize);
        }
        public IEnumerable<SlideModel> Read()
        {
            return GetAll();
        }
        public IEnumerable<SlideModel> ReadID(int ID)
        {
            return GetId(ID);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Slides where c.ID == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Slides.Remove(data);
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
                    var data = Connect_Enttity.Slides.FirstOrDefault(x => x.ID.Equals(i));
                    Connect_Enttity.Slides.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(SlideModel model)
        {
            var data = Connect_Enttity.Slides.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                var entity = new  Slide();
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Image = model.Image;
                entity.URL = model.Url;
                entity.DisplayOrder = Convert.ToInt32(model.DisplayOrder);
                entity.Status = model.Status;
                entity.Content = model.Content;

                Connect_Enttity.Slides.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(SlideModel model)
        {
            var data = Connect_Enttity.Slides.FirstOrDefault(x => x.ID == model.ID);
            if (data != null)
            {
                data.Name = model.Name;
                data.Description = model.Description;
                data.Image = model.Image;
                data.URL = model.Url;
                data.DisplayOrder = Convert.ToInt32(model.DisplayOrder);
                data.Status = model.Status;
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
