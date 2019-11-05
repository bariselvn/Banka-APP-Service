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
    [RoutePrefix("api/Hıslem")]
    public class HIslemController : ApiController
    {
        private UnitOfWorks uow = new UnitOfWorks(new HıslemContext());
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<Islem>))]
        public IHttpActionResult Get()
        {
            var hIslem = uow.HIslemRepository.GetAll();

            return Ok(new { results = hIslem });


        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(Islem))]
        public IHttpActionResult Get(int id)
        {

            var hIslem = uow.HIslemRepository.GetById(id);
            if (hIslem == null)
            {
                return NotFound();
            }
            return Ok(new { results = hIslem });



        }
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Islem))]
        public IHttpActionResult Post(Islem hIslem)
        {
            try
            {
                uow.HIslemRepository.Add(hIslem);
                uow.Commit();
                return Ok(new { results = hIslem });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }
        [HttpDelete]
        [Route("{id}")]

        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (uow.HIslemRepository.GetById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    Islem hIslem = uow.HIslemRepository.GetById(id);
                    uow.HIslemRepository.Remove(hIslem);
                    uow.Commit();
                    return Ok(new { results = hIslem });
                }

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
