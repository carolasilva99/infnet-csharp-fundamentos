using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAniversarios.Pessoa.Data.Repository
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Domain.Pessoa>> ObterTodas();
        Task<Domain.Pessoa> ObterPorId(Guid id);
        void Adicionar(Domain.Pessoa pessoa);
        void Atualizar(Domain.Pessoa pessoa);
        void Apagar(Guid id);
    }
}
