using Domain.Actions.Core;
using System.Web.Http;

namespace ApplicationAPI.Controllers
{
    public class CountriesController : BaseController
    {
        // GET api/values
        public IHttpActionResult  Get()
        {
            return new GetAllCountries<IHttpActionResult>(ServiceProvider)
            {
                OnComplete = (vm) => 
                {
                    if (vm.HasErrors)
                    {
                        return InternalServerError();
                    }
                    else
                    {
                        return Ok(vm);
                    }
                }
            }.Invoke();             
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
