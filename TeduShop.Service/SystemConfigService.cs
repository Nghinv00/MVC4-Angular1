using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeduShop.Data;
using TeduShop.Model;

namespace TeduShop.Service
{
     
    public class SystemConfigService
    {
        public ShopOnlineEntities Connect_Enttity = new ShopOnlineEntities();
        public IList<SystemConfigModel> GetAll()
        {

            IList<SystemConfigModel> result = new List<SystemConfigModel>();
            result = Connect_Enttity.SystemConfigs.Select(x => new SystemConfigModel
            {
                ID = x.ID,
                Code = x.Code,
                ValueString = x.ValueString,
                ValueInt = x.ValueInt

            }).ToList();

            return result;
        }

        public IList<SystemConfigModel> GetId(SystemConfigModel model)
        {
            IList<SystemConfigModel> result = new List<SystemConfigModel>();

            result = Connect_Enttity.SystemConfigs.Where(x => x.ID == model.ID).Select(x => new SystemConfigModel
            {
                ID = x.ID,
                Code = x.Code,
                ValueString = x.ValueString,
                ValueInt = x.ValueInt

            }).ToList();

            return result;
        }

        public IEnumerable<SystemConfigModel> Read()
        {
            return GetAll();
        }
        public IEnumerable<SystemConfigModel> ReadID(SystemConfigModel model)
        {
            return GetId(model);
        }
        public void Deleteone(int Id)
        {

            var data = (from c in Connect_Enttity.SystemConfigs where c.ID == Id select c).FirstOrDefault();

            if (data != null)
            {
                Connect_Enttity.SystemConfigs.Remove(data);
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
                    var data = Connect_Enttity.SystemConfigs.FirstOrDefault(x => x.ID.Equals(i));
                    Connect_Enttity.SystemConfigs.Remove(data);
                    Connect_Enttity.SaveChanges();
                }
                Dispose();

            }

        }

        public void Create(SystemConfigModel model)
        {
            var data = Connect_Enttity.SystemConfigs.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                var entity = new SystemConfig();
                entity.Code = model.Code;
                entity.ValueString = model.ValueString;
                entity.ValueInt = model.ValueInt;
                
                Connect_Enttity.SaveChanges();
                Dispose();
            }
        }

        public void Update(SystemConfigModel model)
        {
            var data = Connect_Enttity.SystemConfigs.FirstOrDefault(x => x.ID == model.ID);
            if (data != null)
            {
                data.Code = model.Code;
                data.ValueString = model.ValueString;
                data.ValueInt = model.ValueInt;

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
