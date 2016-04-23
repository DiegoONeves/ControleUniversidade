using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.Interfaces.Repositories;
using DN.ControleUniversidade.Domain.Interfaces.Services;
using DN.ControleUniversidade.Domain.Validation.CursoValidation;
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

            var resultadoConsistencia = new CursoEstaConsistenteValidation(_cursoRepository).Validar(curso);

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
        public Curso ObterPorId(Guid cursoId)
        {
            return _cursoRepository.GetById(cursoId);
        }
        public Curso ObterPorIdComDependencias(Guid cursoId)
        {
            return _cursoRepository.ObterPorIdComDependencias(cursoId);
        }
        public ValidationResult AtualizarCurso(Curso curso)
        {
            var resultadoValidacao = new ValidationResult();
            var cursoDb = _cursoRepository.GetById(curso.CursoId);

            cursoDb.AtualizarCurso(curso.Nome, curso.Ativo, curso.TipoCurso);

            if (!cursoDb.IsValid)
            {
                resultadoValidacao.AdicionarErro(cursoDb.ResultadoValidacao);
                return resultadoValidacao;
            }

            var resultadoConsistencia = new CursoEstaConsistenteParaAtualizarValidation(_cursoRepository).Validar(cursoDb);

            if (!resultadoConsistencia.IsValid)
            {
                resultadoValidacao.AdicionarErro(resultadoConsistencia);
                return resultadoValidacao;
            }

            _cursoRepository.Update(cursoDb);

            return resultadoValidacao;
        }
        public IEnumerable<Curso> ObterGrid()
        {
            return _cursoRepository.ObterGrid();
        }
        public void Dispose()
        {
            _cursoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        
    }
}
