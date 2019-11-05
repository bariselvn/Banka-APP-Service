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
    [RoutePrefix("api/FaturaIslem")]
    public class FaturaIslemController : ApiController
    {
        private UnitOfWorks uow = new UnitOfWorks(new FaturaIslemContext());

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<FaturaIslem>))]
        public IHttpActionResult Get()
        {
            var FaturaIslemler = uow.FaturaIslemRepository.GetAll();

            return Ok(new { results = FaturaIslemler });


        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(FaturaIslem))]
        public IHttpActionResult Get(int id)
        {

            var faturaIslem = uow.FaturaIslemRepository.GetById(id);
            if (faturaIslem == null)
            {
                return NotFound();
            }
            return Ok(new { results = faturaIslem });



        }
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(FaturaIslem))]
        public IHttpActionResult Post(FaturaIslem  faturaIslem)
        {
            try
            {
                uow.FaturaIslemRepository.Add(faturaIslem);
                uow.Commit();
                return Ok(new { results = faturaIslem });
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
