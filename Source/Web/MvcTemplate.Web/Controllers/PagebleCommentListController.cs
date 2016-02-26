namespace OnlineCrystalStore.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Caching;
    using System.Web.Mvc;
    using OnlineCrystalStore.Data.Common;
    using OnlineCrystalStore.Data.Models;
    using OnlineCrystalStore.Web.Controllers;
    using OnlineCrystalStore.Web.Infrastructure.Mapping;
    using ViewModels.PagebleCommentList;

    public class PagebleCommentListController : BaseController
    {
        private const int ItemsPerPage = 3;

        private IDbRepository<Comment> comments;

        public PagebleCommentListController(IDbRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public ActionResult Index(int id = 1)
        {
            var page = id;
            if (this.HttpContext.Cache[$"comment{page}"] != null)
            {
                var viewModel = (PagebleCommentListViewModel)this.HttpContext.Cache[$"comment{page}"];
                return this.View(viewModel);
            }
            else
            {
                var allItems = this.comments.All().Count();
                var totalPages = (int)Math.Ceiling(allItems / (decimal)ItemsPerPage);

                var commentItems = this.comments.All()
                    .OrderBy(x => x.CreatedOn)
                    .ThenBy(x => x.Id)
                    .Skip((page - 1) * ItemsPerPage)
                    .Take(ItemsPerPage)
                    .To<PagebleCommentViewModel>().ToList();

                var commentViewModel = new PagebleCommentListViewModel()
                {
                    CurrentPage = page,
                    TotalPages = totalPages,
                    Comments = commentItems
                };

                this.HttpContext.Cache.Add($"comment{page}", commentViewModel, null, DateTime.Now.AddMinutes(3), Cache.NoSlidingExpiration, CacheItemPriority.High, null);
                return this.View(commentViewModel);
            }
        }
    }
}
