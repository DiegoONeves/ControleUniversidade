using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Contracts.Repositories;
using DN.ControleUniversidade.Domain.Contracts.Services;
using DN.ControleUniversidade.Domain.Validation.CursoValidations;
using DN.ControleUniversidade.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }
        public ValidationResult AdicionarNovoCurso(Curso curso)
        {
            var resultadoValidacao = new ValidationResult();

            if (!curso.IsValid)
            {
                resultadoValidacao.AdicionarErro(curso.ResultadoValidacao);
                return resultadoValidacao;
            }

            var resultadoConsistencia = new CursoEstaConsistente(_cursoRepository).Validar(curso);

            if (!resultadoConsistencia.IsValid)
            {
                resultadoValidacao.AdicionarErro(resultadoConsistencia);
                return resultadoValidacao;
            }
            _cursoRepository.Add(curso);

            return resultadoValidacao;
        }


        public IEnumerable<Curso> ObterTodos()
        {
            return _cursoRepository.GetAll();
        }


        public void Dispose()
        {
            _cursoRepository.Dispose();
        }


        public Curso ObterPorId(Guid cursoId)
        {
            return _cursoRepository.GetById(cursoId);
        }


        public ValidationResult AtualizarCurso(Guid cursoId, string descricao)
        {
            var resultadoValidacao = new ValidationResult();
            var cursoDb = _cursoRepository.GetById(cursoId);

            cursoDb.AtualizarCurso(descricao);

            if (!cursoDb.IsValid)
            {
                resultadoValidacao.AdicionarErro(cursoDb.ResultadoValidacao);
                return resultadoValidacao;
            }

            var resultadoConsistencia = new CursoEstaConsistenteParaAtualizar(_cursoRepository).Validar(cursoDb);

            if (!resultadoConsistencia.IsValid)
            {
                resultadoValidacao.AdicionarErro(resultadoConsistencia);
                return resultadoValidacao;
            }

            _cursoRepository.Update(cursoDb);

            return resultadoValidacao;
        }
    }
}
