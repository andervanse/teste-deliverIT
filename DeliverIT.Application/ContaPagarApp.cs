using AutoMapper;
using DeliverIT.Application.Interfaces;
using DeliverIT.Data.Interfaces;
using DeliverIT.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliverIT.Application
{
    public class ContaPagarApp : IContaPagarApp
    {
        private readonly IContaPagarRepository _contaPagarRepository;

        public IMapper _mapper { get; }

        public ContaPagarApp(
            IContaPagarRepository contaPagarRepository,
            IMapper mapper)
        {
            _contaPagarRepository = contaPagarRepository;
            _mapper = mapper;
        }

        public async Task<DTO.ContaPagar> AdicionarAsync(DTO.ContaPagar item)
        {
            var contaPagarDomain = _mapper.Map<Domain.ContaPagar>(item);
            await _contaPagarRepository.AdicionarAsync(contaPagarDomain);
            return _mapper.Map<DTO.ContaPagar>(contaPagarDomain);
        }

        public async Task<DTO.ContaPagar> ObterAsync(int id)
        {
            var contaPagar = await _contaPagarRepository.ObterAsync(id);
            return _mapper.Map<DTO.ContaPagar>(contaPagar);
        }

        public async Task<IEnumerable<DTO.ContaPagar>> ListarAsync()
        {
            var domainList = await _contaPagarRepository.ListarAsync();
            var dtoList = _mapper.Map<IEnumerable<DTO.ContaPagar>>(domainList);
            return dtoList;
        }
    }
}
