namespace RegPetServer.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class ArticlesController : BaseController
    {
        public ArticlesController() : base()
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var articles =  this.data.Articles.All();

            return Ok(articles);
        }
    }
}
