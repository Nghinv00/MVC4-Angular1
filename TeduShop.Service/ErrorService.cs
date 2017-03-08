using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeduShop.Data;
using TeduShop.Model;

namespace TeduShop.Service
{
    public class ErrorService
    {
        public ShopOnlineEntities Connect_Enttity = new ShopOnlineEntities();
        public IList<ErrorModel> GetAll()
        {

            IList<ErrorModel> result = new List<ErrorModel>();
            result = Connect_Enttity.Errors.Select(x => new ErrorModel
            {
                ID = x.ID,
                Message = x.Message,
                StackTrace = x.StackTrace,
                CreatedDate = x.CreatedDate

            }).ToList();

            return result;
        }
        public IList<ErrorModel> GetAllPage(int page, int pageSize)
        {

            IList<ErrorModel> result = new List<ErrorModel>();
            result = Connect_Enttity.Errors.Select(x => new ErrorModel
            {
                ID = x.ID,
                Message = x.Message,
                StackTrace = x.StackTrace,
                CreatedDate = x.CreatedDate

            }).OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return result;
        }

        public IList<ErrorModel> GetId(int ID)
        {
            IList<ErrorModel> result = new List<ErrorModel>();

            result = Connect_Enttity.Errors.Where(x => x.ID == ID).Select(x => new ErrorModel
            {
                ID = x.ID,
                Message = x.Message,
                StackTrace = x.StackTrace,
                CreatedDate = x.CreatedDate

            }).ToList();

            return result;
        }

        public IEnumerable<ErrorModel> Read()
        {
            return GetAll();
        }
        public IEnumerable<ErrorModel> ReadPage(int page, int pageSize)
        {
            return GetAllPage(page,pageSize);
        }
        public IEnumerable<ErrorModel> ReadID(int ID)
        {
            return GetId(ID);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.Errors where c.ID == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.Errors.Remove(data);
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
                    var data = Connect_Enttity.Errors.FirstOrDefault(x => x.ID.Equals(i));
                    Connect_Enttity.Errors.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(ErrorModel model)
        {
            var data = Connect_Enttity.Errors.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                var entity = new Error();
                entity.Message = model.Message;
                entity.StackTrace = model.StackTrace;
                entity.CreatedDate = model.CreatedDate;

                Connect_Enttity.Errors.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(ErrorModel model)
        {
            var data = Connect_Enttity.Errors.FirstOrDefault(x => x.ID == model.ID);
            if (data != null)
            {
                data.Message = model.Message;
                data.StackTrace = model.StackTrace;
                data.CreatedDate = model.CreatedDate;

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
