﻿using DN.ControleUniversidade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Domain.Interfaces.Repositories
{
    public interface ICursoRepository : IRepositoryBase<Curso>
    {
        Curso ObterPorDescricao(string descricao);
    }
}
