﻿namespace OnlineCrystalStore.Data.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Image
    {
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public string FileExtension { get; set; }
    }
}
