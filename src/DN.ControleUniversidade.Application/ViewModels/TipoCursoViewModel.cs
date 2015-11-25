using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Application.ViewModels
{
    public class TipoCursoViewModel
    {
        public Guid TipoCursoId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}
