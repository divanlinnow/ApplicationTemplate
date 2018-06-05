using Domain.Enums.Core;

namespace Domain.Models.Core.Precis
{
    public class UserPrecis : EntityBaseDto
    {
        #region Properties

        public virtual Prefix Prefix { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual Suffix Suffix { get; set; }

        public virtual string UserName { get; set; }

        #endregion Properties
    }
}