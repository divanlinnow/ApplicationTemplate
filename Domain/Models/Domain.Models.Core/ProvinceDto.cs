namespace Domain.Models.Core
{
    public class ProvinceDto : EntityBaseDto
    {
        public virtual string ISOCode { get; set; }

        public virtual string Abbreviation { get; set; }

        public virtual string Name { get; set; }
    }
}