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
    [RoutePrefix("api/OIslem")]
    public class OIslemController : ApiController
    {
        private UnitOfWorks uow = new UnitOfWorks(new OıslemContext());

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<Islemler>))]
        public IHttpActionResult Get()
        {
            var oIslem = uow.OıslemlerRepository.GetAll();

            return Ok(new { results = oIslem });


        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(Islemler))]
        public IHttpActionResult Get(int id)
        {

            var oIslem = uow.OıslemlerRepository.GetById(id);
            if (oIslem == null)
            {
                return NotFound();
            }
            return Ok(new { results = oIslem });



        }
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Islemler))]
        public IHttpActionResult Post(Islemler oIslem)
        {
            try
            {
                uow.OıslemlerRepository.Add(oIslem);
                uow.Commit();
                return Ok(new { results = oIslem });
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
                if (uow.OıslemlerRepository.GetById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    Islemler oIslem = uow.OıslemlerRepository.GetById(id);
                    uow.OıslemlerRepository.Remove(oIslem);
                    uow.Commit();
                    return Ok(new { results = oIslem });
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

