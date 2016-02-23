namespace OnlineCrystalStore.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using OnlineCrystalStore.Data.Common;
    using OnlineCrystalStore.Data.Models;
    using OnlineCrystalStore.Web.Controllers;
    using ViewModels.Crystal;

    public class CrystalController : BaseController
    {
        private IDbRepository<Crystal> crystals;
        private IDbRepository<CrystalOrigin> origins;
        private IDbRepository<CrystalType> types;
        private IDbRepository<CrystalPicture> pictures;

        public CrystalController(
                            IDbRepository<Crystal> crystals,
                            IDbRepository<CrystalOrigin> origins,
                            IDbRepository<CrystalType> types,
                            IDbRepository<CrystalPicture> pictures)
        {
            this.crystals = crystals;
            this.origins = origins;
            this.types = types;
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
                Price = model.Price,
                Size = model.Size,
                Weight = model.Weight,
                Description = model.Description,
            };

            var inputType = this.types.All().FirstOrDefault(x => x.Name == model.Type);

            if (inputType == null)
            {
                var newType = new CrystalType()
                {
                    Name = model.Type
                };
                this.types.Add(newType);
                this.types.Save();
                crystal.CrysalTypeId = newType.Id;
            }
            else
            {
                crystal.CrysalTypeId = inputType.Id;
            }

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
