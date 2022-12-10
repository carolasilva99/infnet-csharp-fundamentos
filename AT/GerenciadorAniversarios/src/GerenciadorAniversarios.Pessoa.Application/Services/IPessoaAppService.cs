using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorAniversarios.Pessoa.Application.DTOs;

namespace GerenciadorAniversarios.Pessoa.Application.Services
{
    public interface IPessoaAppService
    {
        Task<PessoaDto> ObterPorId(Guid id);
        Task<IEnumerable<PessoaDto>> ObterTodas();
        Task<IEnumerable<PessoaDto>> BuscarPorNome(string nome);
        Task<IEnumerable<PessoaDto>> ObterAniversariantesDoDia(DateOnly dia);
        void Adicionar(PessoaDto pessoaDto);
        void Atualizar(PessoaDto pessoaDto);
        void Apagar(Guid id);
    }
}
