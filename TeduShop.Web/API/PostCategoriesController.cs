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
    public class PostCategoriesController : ApiController
    {
        PostCategoryService PostCategoryService = new PostCategoryService();
        ShopOnlineEntities Connect_Entity = new ShopOnlineEntities();
        // GET api/PostCategories
        public IEnumerable<PostCategoryModel> Get()
        {
            return PostCategoryService.GetAll();
        }
    }
}
