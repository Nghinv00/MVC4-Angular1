using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeduShop.Data;
using TeduShop.Model;

namespace TeduShop.Service
{
    public class VisitorStatisticService
    {
        public ShopOnlineEntities Connect_Enttity = new ShopOnlineEntities();
        public IList<VisitorStatisticModel> GetAll()
        {

            IList<VisitorStatisticModel> result = new List<VisitorStatisticModel>();
            result = Connect_Enttity.VisitorStatistics.Select(x => new VisitorStatisticModel
            {
                ID = x.ID,
                VisitedDate = x.VisitedDate,
                IPAddress = x.IPAddress

            }).ToList();

            return result;
        }
        public IList<VisitorStatisticModel> GetAllPage(int page, int pageSize)
        {

            IList<VisitorStatisticModel> result = new List<VisitorStatisticModel>();
            result = Connect_Enttity.VisitorStatistics.Select(x => new VisitorStatisticModel
            {
                ID = x.ID,
                VisitedDate = x.VisitedDate,
                IPAddress = x.IPAddress

            }).OrderByDescending(x => x.VisitedDate).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return result;
        }

        public IList<VisitorStatisticModel> GetId(Guid ID)
        {
            IList<VisitorStatisticModel> result = new List<VisitorStatisticModel>();

            result = Connect_Enttity.VisitorStatistics.Where(x => x.ID == ID).Select(x => new VisitorStatisticModel
            {
                ID = x.ID,
                VisitedDate = x.VisitedDate,
                IPAddress = x.IPAddress

            }).ToList();

            return result;
        }

        public IEnumerable<VisitorStatisticModel> Read()
        {
            return GetAll();
        }
        public IEnumerable<VisitorStatisticModel> ReadPage(int page, int pageSize)
        {
            return GetAllPage(page, pageSize);
        }
        public IEnumerable<VisitorStatisticModel> ReadID(Guid ID)
        {
            return GetId(ID);
        }
        public void Deleteone(Guid Id)
        {

            var data = (from c in Connect_Enttity.VisitorStatistics where c.ID == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.VisitorStatistics.Remove(data);
                Connect_Enttity.SaveChanges();
                Dispose();
            }

        }

        public void DeleteAll(Guid[] Id)
        {
            if (Id != null)
            {
                foreach (var i in Id)
                {
                    var data = Connect_Enttity.VisitorStatistics.FirstOrDefault(x => x.ID.Equals(i));
                    Connect_Enttity.VisitorStatistics.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(VisitorStatisticModel model)
        {
            var data = Connect_Enttity.VisitorStatistics.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                var entity = new VisitorStatistic();
                entity.ID = model.ID;
                entity.VisitedDate = model.VisitedDate;
                entity.IPAddress= model.IPAddress;

                Connect_Enttity.VisitorStatistics.Add(entity);
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(VisitorStatisticModel model)
        {
            var data = Connect_Enttity.VisitorStatistics.FirstOrDefault(x => x.ID == model.ID);
            if (data != null)
            {
                data.ID = model.ID;
                data.VisitedDate = model.VisitedDate;
                data.IPAddress = model.IPAddress;

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
