using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeduShop.Data;
using TeduShop.Model;


namespace TeduShop.Service
{
    public class OrderDetaiServvice
    {
        public ShopOnlineEntities Connect_Enttity = new ShopOnlineEntities();
        public IList<OrderDetailModel> GetAll()
        {

            IList<OrderDetailModel> result = new List<OrderDetailModel>();
            result = Connect_Enttity.OrderDetails.Select(x => new OrderDetailModel
            {
                OrderID = x.OrderID,
                ProductID = x.ProductID,
                Quantity = x.Quantity,
                Price = x.Price

            }).ToList();

            return result;
        }
        public IList<OrderDetailModel> GetAllPage(int page, int pageSize)
        {

            IList<OrderDetailModel> result = new List<OrderDetailModel>();
            result = Connect_Enttity.OrderDetails.Select(x => new OrderDetailModel
            {
                OrderID = x.OrderID,
                ProductID = x.ProductID,
                Quantity = x.Quantity,
                Price = x.Price

            }).OrderByDescending(x => x.Price).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return result;
        }

        public IList<OrderDetailModel> GetId(int OrderID, int ProductID)
        {
            IList<OrderDetailModel> result = new List<OrderDetailModel>();

            result = Connect_Enttity.OrderDetails.Where(x => x.OrderID == OrderID && x.ProductID == ProductID).Select(x => new OrderDetailModel
            {
                OrderID = x.OrderID,
                ProductID = x.ProductID,
                Quantity = x.Quantity,
                Price = x.Price

            }).ToList();

            return result;
        }
        public IEnumerable<OrderDetailModel> ReadPage(int page, int pageSize)
        {
            return GetAllPage(page, pageSize);
        }
        public IEnumerable<OrderDetailModel> Read()
        {
            return GetAll();
        }
        public IEnumerable<OrderDetailModel> ReadID(int OrderID, int ProductID)
        {
            return GetId(OrderID,ProductID);
        }
        public void Deleteone(int OrderID, int ProductID)
        {

            var data = (from c in Connect_Enttity.OrderDetails where c.OrderID == OrderID && c.ProductID == ProductID select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.OrderDetails.Remove(data);
                Connect_Enttity.SaveChanges();
                Dispose();
            }

        }

        public void Create(OrderDetailModel model)
        {
            var entity = new OrderDetail();
            entity.OrderID = model.OrderID;
            entity.ProductID = model.ProductID;
            entity.Quantity = model.Quantity;
            entity.Price = model.Price;

            Connect_Enttity.OrderDetails.Add(entity);
            Connect_Enttity.SaveChanges();
            Dispose();
        }

        public void Update(OrderDetailModel model)
        {
            var data = Connect_Enttity.OrderDetails.FirstOrDefault(x => x.OrderID == model.OrderID && x.ProductID == model.ProductID);
            if (data != null)
            {
                data.OrderID = model.OrderID;
                data.ProductID = model.ProductID;
                data.Quantity = model.Quantity;
                data.Price = model.Price;

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
