using ORM.EF.Contexts;
using System.Data.Entity;

namespace ORM.EF.Initializers
{
    public class CoreContextInitializer : DropCreateDatabaseAlways<CoreContext>
    {
        protected override void Seed(CoreContext context)
        {
            base.Seed(context);
        }
    }
}