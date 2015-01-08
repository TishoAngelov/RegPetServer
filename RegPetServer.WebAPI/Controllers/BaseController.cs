namespace RegPetServer.WebAPI.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using RegPetServer.Data;

    public class BaseController : ApiController
    {
        protected IRegPetServerData data;

        public BaseController()
        {
            this.data = new RegPetServerData(RegPetServerDbContext.Create());
        }
    }
}