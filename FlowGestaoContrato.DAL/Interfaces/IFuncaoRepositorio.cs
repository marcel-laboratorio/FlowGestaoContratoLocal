using FlowGestaoContrato.BLL.Models;
using System.Threading.Tasks;

namespace FlowGestaoContrato.DAL.Interfaces
{
    public interface IFuncaoRepositorio : IRepositorioGenerico<Funcao>
    {
        Task AdicionarFuncao(Funcao funcao);

        new Task Atualizar(Funcao funcao);
    }
}
