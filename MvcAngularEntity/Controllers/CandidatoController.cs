using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcAngularEntity.Business;
using MvcAngularEntity.Common;

namespace MvcAngularEntity.Controllers
{
    public class CandidatoController : ApiController
    {
        [ActionName("get"), HttpGet]
        public IEnumerable<Candidato> ListarCandidatos()
        {
            return CandidatoBusiness.Listar();
        }

        public Candidato Get(int Id)
        {
            return CandidatoBusiness.Obter(Id);
        }

        public HttpResponseMessage Post(Candidato entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CandidatoBusiness.Inserir(entity);
                    var response = Request.CreateResponse(HttpStatusCode.Created, entity);
                    return response;

                }

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ModelState);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
               
            }
        
        }

        public HttpResponseMessage Put(Candidato entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CandidatoBusiness.Atualizar(entity);
                    var response = Request.CreateResponse(HttpStatusCode.OK, entity);
                    return response;

                }

                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
 
            }

        }

        public HttpResponseMessage Delete(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var candidato = CandidatoBusiness.Delete(Id);
                    var response = Request.CreateResponse(HttpStatusCode.OK, candidato);
                    return response;

                }

                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }

        }
    }
}
