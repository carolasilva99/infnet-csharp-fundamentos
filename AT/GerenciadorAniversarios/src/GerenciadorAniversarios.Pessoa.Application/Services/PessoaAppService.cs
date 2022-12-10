using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GerenciadorAniversarios.Pessoa.Application.DTOs;
using GerenciadorAniversarios.Pessoa.Data.Repository;

namespace GerenciadorAniversarios.Pessoa.Application.Services
{
    public class PessoaAppService : IPessoaAppService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public PessoaAppService(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }

        public Task<PessoaDto> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PessoaDto>> ObterTodas()
        {
            return _mapper.Map<IEnumerable<PessoaDto>>(await _pessoaRepository.ObterTodas());
        }

        public async Task<IEnumerable<PessoaDto>> BuscarPorNome(string nome)
        {
            var pessoas = await _pessoaRepository.ObterTodas();
            return _mapper.Map<IEnumerable<PessoaDto>>(pessoas.Where(pessoa => pessoa.NomeContem(nome)));
        }

        public async Task<IEnumerable<PessoaDto>> ObterAniversariantesDoDia(DateOnly dia)
        {
            var pessoas = await ObterTodas();
            return pessoas.Where(pessoa => pessoa.DataNascimento == dia);
        }

        public void Adicionar(PessoaDto pessoaDto)
        {
            pessoaDto.Id = Guid.NewGuid();
            var pessoa = _mapper.Map<Domain.Pessoa>(pessoaDto);
            _pessoaRepository.Adicionar(pessoa);
        }

        public void Atualizar(PessoaDto pessoaDto)
        {
            var pessoa = _mapper.Map<Domain.Pessoa>(pessoaDto);
            _pessoaRepository.Atualizar(pessoa);
        }

        public void Apagar(Guid id)
        {
            _pessoaRepository.Apagar(id);
        }
    }
}
