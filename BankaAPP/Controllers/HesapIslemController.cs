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
    [RoutePrefix("api/HesapIslem")]
    public class HesapIslemController : ApiController
    {
        private UnitOfWorks uow = new UnitOfWorks(new HesapIslemlerContext());

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<EftHavale>))]
        public IHttpActionResult Get()
        {
            var hesapIslemler = uow.HesapIslemlerRepository.GetAll();

            return Ok(new { results = hesapIslemler });


        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(HesapIslem))]
        public IHttpActionResult Get(int id)
        {

            var hesapIslem = uow.HesapIslemlerRepository.GetById(id);
            if (hesapIslem == null)
            {
                return NotFound();
            }
            return Ok(new { results = hesapIslem });



        }
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(HesapIslem))]
        public IHttpActionResult Post(HesapIslem hesapIslem)
        {
            try
            {
                uow.HesapIslemlerRepository.Add(hesapIslem);
                uow.Commit();
                return Ok(new { results = hesapIslem });
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
