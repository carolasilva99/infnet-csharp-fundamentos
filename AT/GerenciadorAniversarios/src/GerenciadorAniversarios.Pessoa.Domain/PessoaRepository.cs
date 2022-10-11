using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAniversarios.Pessoa.Domain
{
    public class PessoaRepository
    {
        public ICollection<Pessoa> Pessoas { get; private set; } = new List<Pessoa>();

        public void Adicionar(Pessoa pessoa)
        {
            Pessoas.Add(pessoa);
        }

        public void Remover(Pessoa pessoa)
        {
            Pessoas.Remove(pessoa);
        }

        public Pessoa Obter(Guid id)
        {
            return Pessoas.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Pessoa> Obter(string nome)
        {
            return Pessoas.Where(p => p.NomeCompletoContem(nome));
        }

        public void Alterar(Guid id, Pessoa pessoa)
        {
            Remover(Obter(id));
            Adicionar(pessoa);
        }

        public IEnumerable<Pessoa> ObterAniversariantes()
        {
            return Pessoas.Where(p => p.EAniversarianteHoje());
        }
    }
}
