namespace RegPetServer.WebAPI.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Mvc;
using RegPetServer.Data;

    public class BaseController : ApiController
    {
        private RegPetServerData data;

        public BaseController()
        {

        }
    }
}