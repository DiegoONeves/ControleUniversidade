using DN.ControleUniversidade.Domain.Interfaces.Repositories;
using DN.ControleUniversidade.Domain.Interfaces.Services;
using DN.ControleUniversidade.Domain.Entities;
using System.Collections.Generic;
using System;

namespace DN.ControleUniversidade.Domain.Services
{
    public class TipoCursoService : ITipoCursoService
    {
        private readonly ITipoCursoRepository _tipoCursoRepository;
        public TipoCursoService(ITipoCursoRepository tipoCursoRepository)
        {
            _tipoCursoRepository = tipoCursoRepository;
        }

        public IEnumerable<TipoCurso> ObterTodos()
        {
            return _tipoCursoRepository.GetAll();
        }


        public TipoCurso ObterPorId(System.Guid id)
        {
            return _tipoCursoRepository.GetById(id);
        }

        public void Dispose()
        {
            _tipoCursoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
