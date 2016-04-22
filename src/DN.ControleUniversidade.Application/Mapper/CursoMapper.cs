using DN.ControleUniversidade.Application.ViewModels;
using DN.ControleUniversidade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Application.Mapper
{
    public class CursoMapper
    {
        public static IEnumerable<CursoViewModel> ListCursoParaListCursoViewModel(IEnumerable<Curso> listCursoDomain)
        {
            var cursosViewModel = new List<CursoViewModel>();
            foreach (var item in listCursoDomain)
            {
                var cursoVm = new CursoViewModel();
                cursoVm.CursoId = item.CursoId;
                cursoVm.Descricao = item.Descricao;
                cursoVm.DataCadastro = item.DataCadastro;
                cursoVm.DataAtualizacao = item.DataAtualizacao;
                cursoVm.Ativo = item.Ativo;
                cursosViewModel.Add(cursoVm);
            }

            return cursosViewModel;
        }

        public static Curso CursoViewModelParaCursoDomain(CursoViewModel cursoViewModel, TipoCurso tipoCurso)
        {
             return new Curso(cursoViewModel.CursoId, cursoViewModel.Descricao, cursoViewModel.Ativo, tipoCurso);
        }

        public static CursoViewModel CursoDomainParaCursoViewModel(Curso curso)
        {
            return new CursoViewModel
            {
                CursoId = curso.CursoId,
                Descricao = curso.Descricao,
                DataCadastro = curso.DataCadastro,
                DataAtualizacao = curso.DataAtualizacao,
                Ativo = curso.Ativo
            };
        }

     
    }
}
