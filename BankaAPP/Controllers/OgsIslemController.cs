using BankaDAL.Context;
using BankaDAL.Repositories.UnitOfWorks;
using BankaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BankaAPP.Controllers
{
    [RoutePrefix("api/OgsIslem")]
    public class OgsIslemController : ApiController
    {
        private UnitOfWorks uow = new UnitOfWorks(new OgsIslemContext());

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<OgsIslem>))]
        public IHttpActionResult Get()
        {
            var ogsIslem = uow.OgsIslemlerRepository.GetAll();

            return Ok(new { results = ogsIslem });


        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(OgsIslem))]
        public IHttpActionResult Get(int id)
        {

            var ogsIslem= uow.OgsIslemlerRepository.GetById(id);
            if (ogsIslem == null)
            {
                return NotFound();
            }
            return Ok(new { results = ogsIslem });



        }
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(OgsIslem))]
        public IHttpActionResult Post(OgsIslem ogsIslem)
        {
            try
            {
                uow.OgsIslemlerRepository.Add(ogsIslem);
                uow.Commit();
                return Ok(new { results = ogsIslem });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }

    }
}
