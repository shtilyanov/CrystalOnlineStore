namespace OnlineCrystalStore.Web.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Data.Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using ViewModels.Crystal;

    public class CrystalController : BaseController
    {
        private IDbRepository<Crystal> crystals;
        private IDbRepository<CrystalOrigin> origins;
        private IDbRepository<CrystalPicture> pictures;

        public CrystalController(
                            IDbRepository<Crystal> crystals,
                            IDbRepository<CrystalOrigin> origins,
                            IDbRepository<CrystalPicture> pictures)
        {
            this.crystals = crystals;
            this.origins = origins;
            this.pictures = pictures;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CrystalViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var crystal = new Crystal()
            {
                Name = model.Name,
                Price = model.Price,
                Size = model.Size,
                Weight = model.Weight,
                Description = model.Description,
            };

            var inputOrigin = this.origins.All().FirstOrDefault(x => x.Mine == model.Mine);

            if (inputOrigin == null)
            {
                var newOrigin = new CrystalOrigin()
                {
                    Mine = model.Mine
                };
                this.origins.Add(newOrigin);
                this.origins.Save();
                crystal.CrystalOriginId = newOrigin.Id;
            }
            else
            {
                crystal.CrystalOriginId = inputOrigin.Id;
            }

            if (model.UploadedCrystalImage != null)
            {
                using (var memory = new MemoryStream())
                {
                    model.UploadedCrystalImage.InputStream.CopyTo(memory);
                    var content = memory.GetBuffer();

                    crystal.CrystalPicture = new CrystalPicture
                    {
                        Content = content,
                        FileExtension = model.UploadedCrystalImage.FileName.Split(new[] { '.' }).Last()
                    };
                }
            }

            this.crystals.Add(crystal);
            this.crystals.Save();
            return this.Redirect("/");
        }

        [HttpGet]
        public ActionResult Details(int id = 1)
        {
            var crystalById = this.crystals.All().Where(x => x.Id == id)
            .To<CrystalDetailsViewModel>().ToList();

            return this.View(crystalById[0]);
        }

        [HttpGet]
        public ActionResult Image(int id)
        {
            var image = this.pictures.GetById(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return this.File(image.Content, "image/" + image.FileExtension);
        }
    }
}
