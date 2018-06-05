using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace ORM.EF.Contexts
{
    internal class ContextConfiguration
    {
        [ImportMany(typeof(IEntityConfiguration))]
        public IEnumerable<IEntityConfiguration> Configurations { get; set; }
    }
}