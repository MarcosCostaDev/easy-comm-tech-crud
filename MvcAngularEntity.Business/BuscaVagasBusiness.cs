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
                    var lista = contexto.BuscaVagas.ToList().Select(p => new BuscaVaga()
                    {
                        Id = p.Id,
                        Nome = p.Nome
                        
                    }).ToList();

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
