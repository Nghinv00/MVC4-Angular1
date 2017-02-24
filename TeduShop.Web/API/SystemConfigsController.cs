using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Service;
using TeduShop.Model;
using TeduShop.Data;

namespace TeduShop.Web.API
{
    public class SystemConfigsController : ApiController
    {
        SystemConfigService SystemConfigService = new SystemConfigService();
        ShopOnlineEntities Connect_Entity = new ShopOnlineEntities();
        // GET api/SystemConfigs
        public IEnumerable<SystemConfigModel> Get()
        {
            return SystemConfigService.GetAll();
        }
    }
}
