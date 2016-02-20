namespace OnlineCrystalStore.Data.Models
{
    using OnlineCrystalStore.Data.Common.Models;

    public class Crystal : BaseModel<int>
    {
        public decimal Price { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }

        public int CrysalTypeId { get; set; }

        public virtual CrystalType CrystalType { get; set; }

        public int CrystalOriginId { get; set; }

        public virtual CrystalOrigin CristalOrigin { get; set; }
    }
}
