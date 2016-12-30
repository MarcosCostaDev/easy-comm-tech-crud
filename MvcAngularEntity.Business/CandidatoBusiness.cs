using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcAngularEntity.Common;

namespace MvcAngularEntity.Business
{
    public class CandidatoBusiness
    {
        public static IList<Candidato> Listar()
        {
            using (var contexto = new EasyProgramadoresEntities())
            {
                try
                {
                    return contexto.Candidatoes.ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static Candidato Obter(int Id)
        {
            using (var contexto = new EasyProgramadoresEntities())
            {
                try
                {
                    return contexto.Candidatoes.Find(Id);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static Candidato Inserir(Candidato entity)
        {
            using (var contexto = new EasyProgramadoresEntities())
            {
                try
                {
                    contexto.Candidatoes.Add(entity);
                    contexto.SaveChanges();

                    return entity;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static Candidato Atualizar(Candidato entity)
        {
            using (var contexto = new EasyProgramadoresEntities())
            {
                try
                {
                    contexto.Entry(entity).State = EntityState.Modified;
                    contexto.SaveChanges();
                    return entity;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static Candidato Delete(int Id)
        {
            using (var contexto = new EasyProgramadoresEntities())
            {
                try
                {
                    var entity = contexto.Candidatoes.Find(Id);

                    if (entity == null) throw new Exception("Candidato não encontrado!");

                    contexto.Candidatoes.Remove(entity);
                    contexto.SaveChanges();

                    return entity;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
