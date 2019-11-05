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
    [RoutePrefix("api/Ogs")]
    public class OgsController : ApiController
    {
        private UnitOfWorks uow = new UnitOfWorks(new OgsContext());
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<Ogs>))]
        public IHttpActionResult Get()
        {
            var ogs = uow.OgsRepository.GetAll();

            return Ok(new { results = ogs });


        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(Ogs))]
        public IHttpActionResult Get(int id)
        {

            var ogs = uow.OgsRepository.GetById(id);
            if (ogs == null)
            {
                return NotFound();
            }
            return Ok(new { results = ogs });



        }
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Ogs))]
        public IHttpActionResult Post(Ogs ogs)
        {
            try
            {
                uow.OgsRepository.Add(ogs);
                uow.Commit();
                return Ok(new { results = ogs });
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
                if (uow.OgsRepository.GetById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    Ogs ogs = uow.OgsRepository.GetById(id);
                    uow.OgsRepository.Remove(ogs);
                    uow.Commit();
                    return Ok(new { results = ogs });
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
