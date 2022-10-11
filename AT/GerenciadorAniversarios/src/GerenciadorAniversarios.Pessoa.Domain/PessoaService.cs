using GerenciadorAniversarios.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAniversarios.Pessoa.Domain
{
    public class PessoaService
    {
        public static PessoaRepository PessoaRepository { get; private set; } = new PessoaRepository();

        public void Adicionar(Pessoa pessoa)
        {
            PessoaRepository.Adicionar(pessoa);
        }

        public IEnumerable<Pessoa> Obter(string nome)
        {
            return PessoaRepository.Obter(nome);
        }
    }
}
