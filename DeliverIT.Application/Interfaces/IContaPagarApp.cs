using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliverIT.Application.Interfaces
{
    public interface IContaPagarApp
    {
        Task<DTO.ContaPagar> AdicionarAsync(DTO.ContaPagar item);

        Task<DTO.ContaPagar> ObterAsync(int id);

        Task<IEnumerable<DTO.ContaPagar>> ListarAsync();
    }
}
