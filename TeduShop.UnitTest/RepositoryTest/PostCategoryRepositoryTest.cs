using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeduShop.Data;
using TeduShop.Service;

namespace TeduShop.UnitTest.RepositoryTest
{
    [TestClass]
    internal class PostCategoryRepositoryTest
    {
        private PostCategoryService PostCategoryService;

        [TestInitialize]
        public void Initialize()
        {
            PostCategoryService = new PostCategoryService();
        }

        [TestMethod]
        public void PostCategory_Respository_Create()
        {
            PostCategoryModel PostCategory = new Data.PostCategoryModel();
            PostCategory.Name = "Test category";
            PostCategory.Alias = "Test category";
            PostCategory.Status = true;
            PostCategoryService.Create(PostCategory);
        }
    }
}