using Domain.Services.Core.ServiceProvider;
using System.Web.Http;
using Unity.Attributes;

namespace ApplicationAPI.Controllers
{
    public class BaseController : ApiController
    {
        [Dependency]
        public IServiceProviderCore ServiceProvider { get; set; }
    }
}
