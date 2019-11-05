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
    [RoutePrefix("api/Hesap")]
    public class HesapController : ApiController
    {
        private UnitOfWorks uow = new UnitOfWorks(new HesapContext());

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<Hesap>))]
        public IHttpActionResult Get()
        {
            var hesaplar = uow.HesapRepository.GetAll();

            return Ok(new { results = hesaplar });


        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(Hesap))]
        public IHttpActionResult Get(int id)
        {

            var Hesap = uow.MusteriRepository.GetById(id);
            if (Hesap == null)
            {
                return NotFound();
            }
            return Ok(new { results = Hesap });



        }
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Hesap))]
        public IHttpActionResult Post(Hesap hesap)
        {
            try
            {
                uow.HesapRepository.Add(hesap);
                uow.Commit();
                return Ok(new { results = hesap });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }
        [HttpGet]
        [Route("hesapID/{MusteriID}")]
        [ResponseType(typeof(IEnumerable<Hesap>))]
        public IHttpActionResult hesapGetir(string MusteriID)
        {
            IEnumerable<Hesap> hesapId = uow.HesapRepository.hesapGetir(Convert.ToInt32(MusteriID));


            if (hesapId == null)
            {
                return BadRequest(); //
            }
            else
            {
                return Ok(new { results = hesapId });

            }
        }
        [HttpGet]
        [Route("hesaplar/{MusteriID}/{ekNO}")]
       
        public IHttpActionResult hesapDondur(string MusteriID,string ekNO)
        {
            var hesabımId = uow.HesapRepository.hesapDondur(Convert.ToInt32(MusteriID), Convert.ToInt32(ekNO));


            if (hesabımId == 0)
            {
                return BadRequest(); //
            }
            else
            {
                return Ok(new { results = hesabımId });

            }
        }
    }
}
