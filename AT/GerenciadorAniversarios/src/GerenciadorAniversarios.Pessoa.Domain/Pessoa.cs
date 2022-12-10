using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GerenciadorAniversarios.Pessoa.Domain
{
    public class Pessoa
    {
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateOnly DataNascimento { get; private set; }

        public Pessoa(Guid id, string nome, string sobrenome, DateOnly dataNascimento)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
        }

        public string MontarNomeCompleto()
        {
            return $"{Nome} {Sobrenome}";
        }

        public int DiasParaProximoAniversario()
        {
            var dataAtual = DateOnly.FromDateTime(DateTime.Now);
            var dataAniversario = DataNascimento.AddYears(dataAtual.Year - DataNascimento.Year);

            // Se o aniversário já passou
            if (dataAniversario < dataAtual)
                dataAniversario = dataAniversario.AddYears(1);

            var diasParaAniversario = dataAniversario.DayNumber - dataAtual.DayNumber;

            if (diasParaAniversario < 0)
                diasParaAniversario *= -1;

            return diasParaAniversario;
        }

        public bool NomeContem(string nome)
        {
            var nomeCompleto = MontarNomeCompleto();

            return nomeCompleto.ToLowerInvariant().Contains(nome.Trim().ToLowerInvariant());
        }

        public override string ToString()
        {
            return $"Nome: {MontarNomeCompleto()}\n" +
                   $"Data de nascimento: {DataNascimento}\n" +
                   $"Dias para o próximo aniversário: {DiasParaProximoAniversario()}";
        }
    }
}
