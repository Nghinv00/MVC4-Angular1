using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Data;
using TeduShop.Model;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;

namespace TeduShop.Web.API
{
    public class ProductCategorysController : ApiControllerBase
    {
        private ProductCategoryService ProductCategoryService = new ProductCategoryService();
        private ShopOnlineEntities Connect_Entity = new ShopOnlineEntities();

        // GET api/SystemConfigs
        [ActionName("getall")]
        [HttpGet]
        public HttpResponseMessage getAll(HttpRequestMessage request, string keyword)
        {

            return CreateHttpResponse(request, () =>
            {
                var model = ProductCategoryService.Read(keyword);
                var response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }

        [ActionName("getallparent")]
        [HttpGet]
        public HttpResponseMessage getAllParent(HttpRequestMessage request)
        {

            return CreateHttpResponse(request, () =>
            {
                var model = ProductCategoryService.ReadParent();
                var response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }

        [ActionName("getbyid")]
        [HttpGet]
        public HttpResponseMessage getById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = ProductCategoryService.ReadID(id);

                var response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [ActionName("getallpage")]
        [HttpGet]
        public HttpResponseMessage getAllPage(HttpRequestMessage request,string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var responseData = ProductCategoryService.ReadPage(keyword,page, pageSize);

                totalRow = ProductCategoryService.GetAll(keyword).Count;

                var paginationSet = new PaginationSet<ProductCategoryModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        

        [ActionName("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductCategoryModel ProductCategoryModel)
        {
            return CreateHttpResponse(request, () =>
            {
                var a = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var ProductCategoryService = new ProductCategoryService();
                    ProductCategoryService.Create(ProductCategoryModel);
                    //var responseData = true;
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }

        [ActionName("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryModel ProductCategoryModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var ProductCategoryService = new ProductCategoryService();
                    ProductCategoryService.Update(ProductCategoryModel);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        [ActionName("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var ProductCategoryService = new ProductCategoryService();
                    ProductCategoryService.Deleteone(id);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }

        [ActionName("deletemuti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, int[] id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var ProductCategoryService = new ProductCategoryService();
                    ProductCategoryService.DeleteAll(id);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}
