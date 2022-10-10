using GerenciadorAniversarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAniversarios.Repositories
{
    public class PessoaRepository
    {
        public static IEnumerable<Pessoa> Pessoas { get; private set; }

        public PessoaRepository()
        {
            Pessoas = new List<Pessoa>();
        }

        public IEnumerable<Pessoa> BuscarPessoas(string nome)
        {
            return Pessoas.Where(p => p.NomeContem(nome));
        }

        public void AdicionarPessoa(Pessoa pessoa)
        {
            Pessoas = Pessoas.Append(pessoa);
        }
    }
}
