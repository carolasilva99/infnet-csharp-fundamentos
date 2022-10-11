using GerenciadorAniversarios.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GerenciadorAniversarios.Pessoa.Domain
{
    public class Pessoa : Entity
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public Pessoa(string nome, string sobrenome, DateTime dataNascimento)
        {
            Nome = nome.Trim();
            Sobrenome = sobrenome.Trim();
            DataNascimento = dataNascimento;

            Validar();
        }

        public string ObterNomeCompleto()
        {
            return $"{Nome} {Sobrenome}";
        }
        
        public bool NomeCompletoContem(string nome)
        {
            return ObterNomeCompleto().ToLower().Contains(nome.ToLower().Trim());
        }

        public void AlterarNome(string nome)
        {
            Validacoes.ValidarSeVazio(nome, "O campo Nome da pessoa não pode estar vazio");
            Nome = nome.Trim();
        }

        public void AlterarSobrenome(string sobrenome)
        {
            Validacoes.ValidarSeVazio(sobrenome, "O campo Sobrenome da pessoa não pode estar vazio");
            Nome = sobrenome.Trim();
        }

        public void AlterarDataNascimento(DateTime dataNascimento)
        {
            DataNascimento = dataNascimento;
        }

        public int ObterDiasParaProximoAniversario()
        {
            DateTime dataAtual = DateTime.Today;
            DateTime dataAniversario = DataNascimento.AddYears(dataAtual.Year - DataNascimento.Year);

            // Se o aniversário já passou
            if (dataAniversario < DateTime.Today)
                dataAniversario = dataAniversario.AddYears(1);

            int diasParaAniversario = (dataAniversario - dataAtual).Days;

            if (diasParaAniversario < 0)
                diasParaAniversario *= -1;

            return diasParaAniversario;
        }

        public bool EAniversarianteHoje()
        {
            return ObterDiasParaProximoAniversario() == 0;
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da pessoa não pode estar vazio");
            Validacoes.ValidarSeVazio(Sobrenome, "O campo Sobrenome da pessoa não pode estar vazio");
        }

        public override string ToString()
        {
            return $"Nome completo: {ObterNomeCompleto()}\n" +
                $"Data de nascimento: {DataNascimento.ToShortDateString()}\n" +
                $"Faltam {ObterDiasParaProximoAniversario()} dias para o próximo aniversário";
        }
    }
}
