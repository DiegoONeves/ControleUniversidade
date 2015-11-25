using DN.ControleUniversidade.Application.ViewModels;
using DN.ControleUniversidade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Application.Mapper
{
    public class TipoCursoMapper
    {
        public static IEnumerable<TipoCursoViewModel> ListTipoCursoParaListTipoCursoViewModel(IEnumerable<TipoCurso> listTipoCursoDomain)
        {
            var tiposCursosViewModel = new List<TipoCursoViewModel>();
            foreach (var item in listTipoCursoDomain)
            {
                var tipoCursoVm = new TipoCursoViewModel();
                tipoCursoVm.TipoCursoId = item.TipoCursoId;
                tipoCursoVm.Descricao = item.Descricao;
                tipoCursoVm.Ativo = item.Ativo;
                tiposCursosViewModel.Add(tipoCursoVm);
            }

            return tiposCursosViewModel;
        }
    }
}
