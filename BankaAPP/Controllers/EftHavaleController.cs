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
    [RoutePrefix("api/EftHavale")]
    public class EftHavaleController : ApiController
    {
        private UnitOfWorks uow = new UnitOfWorks(new EftHavaleContext());
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<EftHavale>))]
        public IHttpActionResult Get()
        {
            var efthavaleler = uow.EftHavaleRepository.GetAll();

            return Ok(new { results = efthavaleler });


        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(EftHavale))]
        public IHttpActionResult Get(int id)
        {

            var eftHavale = uow.EftHavaleRepository.GetById(id);
            if (eftHavale == null)
            {
                return NotFound();
            }
            return Ok(new { results = eftHavale });



        }
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(EftHavale))]
        public IHttpActionResult Post(EftHavale eftHavale)
        {
            try
            {
                uow.EftHavaleRepository.Add(eftHavale);
                uow.Commit();
                return Ok(new { results = eftHavale });
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
