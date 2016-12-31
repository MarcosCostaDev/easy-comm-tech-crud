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
        public static IEnumerable<Candidato> Listar()
        {
            IEnumerable<Candidato> lista;
            using (var contexto = new EasyProgramadoresEntities())
            {
                try
                {
                    var query = contexto.Candidatoes.ToList().Select(p => new Candidato()
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        AreaInteresse = p.AreaInteresse,
                        Cidade = p.Cidade,
                        ComentarioAdicional = p.ComentarioAdicional,
                        ConhecimentoLinguagens = p.ConhecimentoLinguagens,
                        ConhecimentoSGC = p.ConhecimentoSGC,
                        Email = p.Email,
                        Estado = p.Estado,
                        HorarioDisponivel = p.HorarioDisponivel,
                        HorasDisponivel = p.HorasDisponivel,
                        InformacaoBancaria = p.InformacaoBancaria,
                        Linkedin = p.Linkedin,
                        NidelIos = p.NidelIos,
                        NivelAndroid = p.NivelAndroid,
                        NivelAngularJs = p.NivelAngularJs,
                        NivelAspNetMvc = p.NivelAspNetMvc,
                        NivelBootstrap = p.NivelBootstrap,
                        NivelCSharp = p.NivelCSharp,
                        NivelIonic = p.NivelIonic,
                        NivelJquery = p.NivelJquery,
                        NivelPhp = p.NivelPhp,
                        NivelWordpress = p.NivelWordpress,
                        Portifolio = p.Portifolio,
                        PretencaoSalario = p.PretencaoSalario,
                        PretencaoSalarioHora = p.PretencaoSalarioHora,
                        Skype = p.Skype,
                        Telefone = p.Telefone
                    });

                   
                    lista = query.ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return lista;
        }

        public static Candidato Obter(int Id)
        {
            using (var contexto = new EasyProgramadoresEntities())
            {
                try
                {
                    return contexto.Candidatoes.Where(p => p.Id == Id).Include(x => x.CandidatoBuscaVagas.Select(p => p.BuscaVaga).Select(p => p.CandidatoBuscaVagas)).FirstOrDefault();

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


                    foreach (var buscaVaga in entity.BuscaVagasList)
                    {
                        contexto.CandidatoBuscaVagas.Add(
                       new CandidatoBuscaVaga()
                       {
                           CandidatoId = entity.Id,
                           BuscaVagaId = buscaVaga.Id
                       });
                    }


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

                    contexto.CandidatoBuscaVagas.RemoveRange(contexto.CandidatoBuscaVagas.Where(p => p.CandidatoId == entity.Id));

                    foreach (var item in entity.BuscaVagasList)
                    {
                        contexto.CandidatoBuscaVagas.Add(new CandidatoBuscaVaga()
                        {
                            CandidatoId = entity.Id,
                            BuscaVagaId = item.Id,
                            Selecionado = true
                        });
                    }

                    contexto.SaveChanges();

                    entity =
                        contexto.Candidatoes.Where(p => p.Id == entity.Id)
                            .Include(p => p.CandidatoBuscaVagas)
                            .ToList()
                            .FirstOrDefault();
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
