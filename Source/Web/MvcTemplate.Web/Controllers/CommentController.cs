namespace OnlineCrystalStore.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Controllers;
    using Data.Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using ViewModels.Comment;

    public class CommentController : BaseController
    {
        private IDbRepository<Comment> comments;

        public CommentController(IDbRepository<Comment> comments)
        {
            this.comments = comments;
        }

        [HttpGet]
        public ActionResult ListComments()
        {
            var allComments = this.comments.All().OrderByDescending(x => x.CreatedOn)
                .To<CommentViewModel>().ToList();
            return this.View(allComments);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var comment = new Comment
            {
                Title = model.Title,
                Content = model.Content
            };
            var userId = this.User.Identity.GetUserId();
            comment.AuthorId = userId;
            this.comments.Add(comment);
            this.comments.Save();

            return this.RedirectToAction("ListComments");
        }
    }
}
