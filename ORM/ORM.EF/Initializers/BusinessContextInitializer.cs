using ORM.EF.Contexts;
using System.Data.Entity;

namespace ORM.EF.Initializers
{
    public class BusinessContextInitializer : DropCreateDatabaseAlways<BusinessContext>
    {
        protected override void Seed(BusinessContext context)
        {
            base.Seed(context);
        }
    }
}