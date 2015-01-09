namespace RegPetServer.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using RegPetServer.Models;
    using RegPetServer.WebAPI.InputModels;
    using Microsoft.AspNet.Identity;
    using RegPetServer.WebAPI.ViewModels;

    public class ArticlesController : BaseController
    {
        public ArticlesController()
            : base()
        {
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(ArticleInputModel articleModel)
        {
            var currentUserId = this.User.Identity.GetUserId();

            var category = GetCategory(articleModel.CategoryName);
            var tags = GetTags(articleModel.TagNames);

            var article = new Article
            {
                AuthorId = currentUserId,
                DateCreated = DateTime.Now,
                Title = articleModel.Title,
                Content = articleModel.Content,
                CategoryId = category.Id,
                Tags = tags,
            };

            this.data.Articles.Add(article);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var articles = this.data.Articles.All().Select(a => new ArticleViewModel
            {
                Id = a.Id,
                Author = a.Author.UserName,
                AuthorId = a.AuthorId,
                Category = a.Category.Name,
                CategoryId = a.CategoryId,
                Content = a.Content,
                DateCreated = a.DateCreated,
                Tags = a.Tags.Select(t => t.Name).ToList<string>(),
                Title = a.Title
            });

            return Json(articles);
        }

        private Category GetCategory(string categoryName)
        {
            var category = this.data.Categories.All().FirstOrDefault(c => c.Name == categoryName);

            if (category == null)
            {
                category = new Category
                {
                    Name = categoryName
                };
                this.data.Categories.Add(category);
            }

            return category;
        }

        private HashSet<Tag> GetTags(IEnumerable<string> tagNames)
        {
            HashSet<Tag> tags = new HashSet<Tag>();

            foreach (var newTagName in tagNames)
            {
                var tag = this.data.Tags.All()
                    .FirstOrDefault(t => t.Name == newTagName);
                if (tag == null)
                {
                    tag = new Tag { Name = newTagName };
                    this.data.Tags.Add(tag);
                }

                tags.Add(tag);
            }

            return tags;
        }
    }
}
