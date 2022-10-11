using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAniversarios.Models
{
    public class Pessoa
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public Pessoa(string nome, string sobrenome, DateTime dataNascimento)
        {
            Nome = nome.Trim();
            Sobrenome = sobrenome.Trim();
            DataNascimento = dataNascimento;
        }

        public string MontarNomeCompleto()
        {
           return $"{Nome} {Sobrenome}";
        }

        public int DiasParaProximoAniversario()
        {
            DateTime dataAtual = DateTime.Today;
            DateTime dataAniversario = DataNascimento.AddYears(dataAtual.Year - DataNascimento.Year);

            // Se o aniversário já passou
            if (dataAniversario < DateTime.Now)
                dataAniversario = dataAniversario.AddYears(1);

            int diasParaAniversario = (dataAniversario - dataAtual).Days;

            if (diasParaAniversario < 0)
                diasParaAniversario *= -1;

            return diasParaAniversario;
        }

        public bool NomeContem(string nome)
        {
            string nomeCompleto = MontarNomeCompleto();

            return nomeCompleto.ToLowerInvariant().Contains(nome.Trim().ToLowerInvariant());
        }
    }
}
