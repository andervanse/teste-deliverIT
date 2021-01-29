using DeliverIT.Data.Interfaces;
using DeliverIT.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliverIT.Data
{
    public class ContaPagarRepository : IContaPagarRepository
    {
        private readonly DataContext _context;

        public ContaPagarRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> AdicionarAsync(ContaPagar item)
        {

            if (item.Id > 0)
            {
                _context.Attach(item);
            }
            else
            {
               _context.Add(item);
            }

            return await _context.SaveChangesAsync();
        }
        public async Task<ContaPagar> ObterAsync(int id)
        {
            return await _context.ContasPagar.FindAsync(id);
        }

        public async Task<IEnumerable<ContaPagar>> ListarAsync()
        {
            return await _context.ContasPagar.AsNoTracking().ToListAsync();
        }

    }
}
