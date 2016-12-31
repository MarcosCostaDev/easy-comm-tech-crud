using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcAngularEntity.Common;

namespace MvcAngularEntity.Business
{
    public class BuscaVagasBusiness
    {
        public static IList<BuscaVaga> Listar()
        {
            using (var contexto = new EasyProgramadoresEntities())
            {
                try
                {
                    var lista = contexto.BuscaVagas.Include(p => p.CandidatoBuscaVagas).ToList();

                    return lista;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
