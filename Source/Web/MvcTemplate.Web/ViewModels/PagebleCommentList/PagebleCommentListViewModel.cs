namespace OnlineCrystalStore.Web.ViewModels.PagebleCommentList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PagebleCommentListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public ICollection<PagebleCommentViewModel> Comments { get; set; }
    }
}
