using BankaDAL.Context;
using BankaDAL.Repositories.UnitOfWorks;
using BankaData;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BankaAPP.Controllers
{
    [RoutePrefix("api/Musteri")]
    
    public class MusteriController : ApiController
    {
        private UnitOfWorks uow = new UnitOfWorks(new MusteriContext());

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<Musteri>))]
        public IHttpActionResult Get()
        {    
                var musteriler = uow.MusteriRepository.GetAll();
              
                return Ok(new { results = musteriler });
            
           
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(Musteri))]
        public IHttpActionResult Get(int id)
        {

            var musteri = uow.MusteriRepository.GetById(id);
            if (musteri == null)
            {
                return NotFound();
            }
            return Ok(new { results = musteri });



        }
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Musteri))]
        public IHttpActionResult Post(Musteri musteri)
        {
            try
            {
                uow.MusteriRepository.Add(musteri);
                uow.Commit();
                return Ok(new { results = musteri });
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }

        }

        [HttpPut]
        [Route("")]
        [ResponseType(typeof(Musteri))]
        public IHttpActionResult Put(Musteri musteri)
        {
            try
            {
                var guncellenecek = uow.MusteriRepository.GetById(musteri.MusteriID);
                //id ye ait kayıt yok ise
                if (musteri == null)
                {
                    return NotFound();
                }
                //urun modeli doğrulanmadıysa
                else if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }
                //OK
                else
                {

                    guncellenecek.Adres = musteri.Adres;
                    guncellenecek.sifre = musteri.sifre;
                    guncellenecek.İletisim = musteri.İletisim;


                    uow.Commit();
                    return Ok(new { results = musteri });
                }
            }
            catch (Exception e)
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
                errorResponse.ReasonPhrase = e.Message;
                throw new HttpResponseException(errorResponse);
            }
        }
        
        [HttpGet]
        [Route("Login/{Tckn}/{sifre}")]
        public IHttpActionResult login(string Tckn, string sifre)
        {
            var loginId = uow.MusteriRepository.login(Tckn, sifre);
            

            if (loginId == 0)
            {
                return BadRequest(); //
            }
            else
            {
                return Ok(new { results = loginId });

            }
        }
    }
}
