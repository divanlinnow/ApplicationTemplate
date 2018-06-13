using System.Data.Entity.ModelConfiguration.Configuration;

namespace ORM.EF.Contexts
{
    interface IEntityConfiguration
    {
        void AddConfiguration(ConfigurationRegistrar registrar);
    }
}