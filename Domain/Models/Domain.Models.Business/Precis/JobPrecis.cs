using Domain.Models.Core;

namespace Domain.Models.Business.Precis
{
    public class JobPrecis : EntityBaseDto
    {
        public virtual string Title { get; set; }
    }
}