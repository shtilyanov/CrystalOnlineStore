namespace OnlineCrystalStore.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Data.Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using OnlineCrystalStore.Web.Areas.Administration.ViewModels;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class CommentsController : Controller
    {
        private IDbRepository<Comment> comments;

        public CommentsController(IDbRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Comments_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.comments.AllWithDeleted()
                .To<CommentViewModel>()
                .ToDataSourceResult(request);
            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Create([DataSourceRequest]DataSourceRequest request, CommentInputModel comment)
        {
            var newId = 0;
            if (this.ModelState.IsValid)
            {
                var entity = new Comment
                {
                    Title = comment.Title,
                    Content = comment.Content,
                    AuthorId = this.User.Identity.GetUserId()
                };
                this.comments.Add(entity);
                this.comments.Save();
                newId = entity.Id;
            }

            var commentToDisplay = this.comments.AllWithDeleted().To<CommentViewModel>().FirstOrDefault(x => x.Id == newId);
            return this.Json(new[] { comment }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Update([DataSourceRequest]DataSourceRequest request, CommentInputModel comment)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.comments.GetById(comment.Id);

                entity.Title = comment.Title;
                entity.Content = comment.Content;

                this.comments.Save();
            }

            var commentToDisplay = this.comments.AllWithDeleted().To<CommentViewModel>().FirstOrDefault(x => x.Id == comment.Id);
            return this.Json(new[] { comment }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Destroy([DataSourceRequest]DataSourceRequest request, Comment comment)
        {
            var entity = this.comments.All().FirstOrDefault(x => x.Id == comment.Id);
            this.comments.Delete(entity);
            this.comments.Save();

            return this.Json(new[] { comment }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }
    }
}
