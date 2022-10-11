using GerenciadorAniversarios.Core.InteracaoUsuario;
using GerenciadorAniversarios.Pessoa.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class Program
    {
        public static PessoaService PessoaService { get; set; } = new PessoaService();

        static void Main(string[] args)
        {
            int opcao = 0;

            while (opcao != 5)
            {
                Interface.ImprimirMenu();

                opcao = SolicitarEntradaUsuario.SolicitarNumeroAoUsuario("");

                switch(opcao)
                {
                    case 1:
                        AdicionarPessoa();
                        break;
                    case 2:
                        ConsultarPessoa();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
            }
        }

        private static void AdicionarPessoa()
        {
            Interface.ImprimirCabecalho();
            Interface.Imprimir("ADICIONAR AMIGO\n");

            string nome = SolicitarEntradaUsuario.SolicitarStringAoUsuario("Digite o nome do novo amigo: ");
            string sobrenome = SolicitarEntradaUsuario.SolicitarStringAoUsuario("Digite o sobrenome do novo amigo: ");
            DateTime dataNascimento = SolicitarEntradaUsuario.SolicitarDataAoUsuario("Digite a data de nascimento do novo amigo: ");

            Pessoa pessoa = new Pessoa(nome, sobrenome, dataNascimento);

            PessoaService.Adicionar(pessoa);
        }

        private static void ConsultarPessoa()
        {
            Interface.ImprimirCabecalho();
            Interface.Imprimir("CONSULTAR AMIGO\n");

            string nome = SolicitarEntradaUsuario.SolicitarStringAoUsuario("Digite o nome do amigo que está procurando: ");

            IEnumerable<Pessoa> pessoasEncontradas = PessoaService.Obter(nome);

            Interface.ImprimirCabecalho();
            Interface.Imprimir("CONSULTAR AMIGO\n");

            if (!pessoasEncontradas.Any())
            {
                Interface.ImprimirEAguardarEnter($"Nenhuma pessoa foi encontrada com o nome {nome}");
            }

            foreach (Pessoa pessoa in pessoasEncontradas)
            {
                Interface.Imprimir(pessoa.ToString());
                Interface.Imprimir("\n");
            }

            Interface.ImprimirEAguardarEnter("\n");
        }
    }
}
