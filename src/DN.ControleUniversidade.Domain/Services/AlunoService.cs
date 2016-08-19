using DN.ControleUniversidade.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.ControleUniversidade.Domain.Entities;
using DN.ControleUniversidade.Domain.ValueObjects;
using DN.ControleUniversidade.Domain.Interfaces.Repositories;
using DN.ControleUniversidade.Domain.Validation.AlunoValidation;

namespace DN.ControleUniversidade.Domain.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        public ValidationResult AdicionarNovoAluno(Aluno aluno)
        {
            var resultadoValidacao = new ValidationResult();

            if (!aluno.IsValid)
            {
                resultadoValidacao.AdicionarErro(aluno.ResultadoValidacao);
                return resultadoValidacao;
            }

            var resultadoConsistencia = new AlunoEstaConsistenteParaCadastroValidation(_alunoRepository).Validar(aluno);

            if (!resultadoConsistencia.IsValid)
            {
                resultadoValidacao.AdicionarErro(resultadoConsistencia);
                return resultadoValidacao;
            }
            _alunoRepository.Add(aluno);

            return resultadoValidacao;
        }

        public void Dispose()
        {
            _alunoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
