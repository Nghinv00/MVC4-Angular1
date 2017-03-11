using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Data;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;

namespace TeduShop.Web.API
{
    public class PostCategoriesController : ApiControllerBase
    {
        PostCategoryService PostCategoryService = new PostCategoryService();
        ShopOnlineEntities Connect_Entity = new ShopOnlineEntities();
        // GET api/PostCategories/getall

        [HttpGet]
        [ActionName("getall")]
        public HttpResponseMessage getAll(HttpRequestMessage request, string keyword)
        {

            return CreateHttpResponse(request, () =>
            {

                var model = PostCategoryService.Read(keyword);
                var response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }

        [HttpGet]
        [ActionName("getallpage")]
        public HttpResponseMessage getAllPage(HttpRequestMessage request,string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var responseData = PostCategoryService.ReadPage(keyword,page, pageSize);

                totalRow = PostCategoryService.GetAll(keyword).Count;

                var paginationSet = new PaginationSet<PostCategoryModel>()
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

        [HttpGet]
        [ActionName("getbyid")]
        public HttpResponseMessage getById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = PostCategoryService.ReadID(id);

                var response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [HttpPost]
        [ActionName("create")]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, PostCategoryModel PostCategoryModel)
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
                    var PostCategoryService = new PostCategoryService();
                    PostCategoryService.Create(PostCategoryModel);
                    //var responseData = true;
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }

        [HttpPut]
        [ActionName("update")]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, PostCategoryModel PostCategoryModel)
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
                    var PostCategoryService = new PostCategoryService();
                    PostCategoryService.Update(PostCategoryModel);
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
                    var PostCategoryService = new PostCategoryService();
                    PostCategoryService.Deleteone(id);
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
                    var PostCategoryService = new PostCategoryService();
                    PostCategoryService.DeleteAll(id);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
        
    }
}
