using DeliverIT.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliverIT.Data.Interfaces
{
    public interface IContaPagarRepository
    {
        Task<int> AdicionarAsync(ContaPagar item);
        Task<ContaPagar> ObterAsync(int id);
        Task<IEnumerable<ContaPagar>> ListarAsync();
    }
}
