using System.Reflection;
using System.Xml.Linq;

namespace ORM.EF.Helpers
{
    public class DataSeedingHelper
    {
        /// <summary>
        /// Loads XML from embedded resource file for seeding of database.
        /// </summary>
        /// <param name="resource">The string name of the XML resource file in the format 'DefaultNamespace.Folder.Subfolder.FileName.FileExtension'</param>
        /// <returns></returns>
        public XDocument SeedFromXmlFile(string resource)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(resource);
            return XDocument.Load(stream);
        }
    }
}