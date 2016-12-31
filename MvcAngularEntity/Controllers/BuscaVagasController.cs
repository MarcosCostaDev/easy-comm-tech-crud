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
    public class BuscaVagasController : ApiController
    {
        [ActionName("get"), HttpGet]
        public IEnumerable<BuscaVaga> ListarBuscaVagas()
        {
            var lista = BuscaVagasBusiness.Listar();

            return lista;
            
        }

    }
}