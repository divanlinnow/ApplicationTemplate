using Domain.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ApplicationTemplate.Controllers
{
    public class CountryController : ApiController
    {
        ICountryService _service;

        public CountryController(ICountryService service)
        {
            _service = service;
        }

        //[Route("")]
        public ActionResult Get(int? Id)
        {
            var result = _service.FindCountryById(Id);
        }
    }
}
