using GerenciadorAniversarios.Models;
using GerenciadorAniversarios.Repositories;
using InteracaoUsuario;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorAniversarios
{
    internal class Program
    {
        public static PessoaRepository pessoaRepository = new PessoaRepository();
        static void Main(string[] args)
        {
            int opcao = 0;

            while (opcao != 3)
            {
                try
                {
                    ImprimirCabecalho();
                    Console.WriteLine("Selecione uma das opções abaixo: ");
                    Console.WriteLine("1- Adicionar nova pessoa");
                    Console.WriteLine("2- Pesquisar pessoas");
                    Console.WriteLine("3- Sair");

                    opcao = SolicitarEntrada.SolicitarNumeroAoUsuario(string.Empty);

                    switch (opcao)
                    {
                        case 1:
                            AdicionarPessoa();
                            break;
                        case 2:
                            ConsultarPessoas();
                            break;
                        case 3:
                            Console.WriteLine("Obrigada pela participação");
                            break;
                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }
                    
                    Console.ReadLine();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Opção inválida! Erro: " + ex.Message);
                }
            }

        }

        private static void ConsultarPessoas()
        {
            ImprimirCabecalho();

            string nome = SolicitarEntrada.SolicitarStringAoUsuario("Digite o nome, ou parte do nome, da pessoa que deseja encontrar: ");

            IEnumerable<Pessoa> pessoas = pessoaRepository.BuscarPessoas(nome);

            if (!pessoas.Any())
            {
                Console.WriteLine("Nenhuma pessoa cadastrada com esse nome!");
                return;
            }

            ImprimirCabecalho();    
            Console.WriteLine("Selecione uma das opções abaixo para visualizar os dados de uma das pessoas encontradas: ");
            int indice = 0;

            foreach (Pessoa pessoa in pessoas)
            {
                Console.WriteLine($"{indice}- {pessoa.MontarNomeCompleto()}");
                indice++;
            }

            int opcao = SolicitarEntrada.SolicitarNumeroAoUsuario("Opção escolhida: ");

            if (opcao < 0 || opcao >= pessoas.Count())
            {
                Console.WriteLine("Opção inválida!");
                return;
            }

            Console.WriteLine();
            Pessoa pessoaEscolhida = pessoas.ElementAt(opcao);
            Console.WriteLine($"Nome completo: {pessoaEscolhida.MontarNomeCompleto()}");
            Console.WriteLine($"Data de nascimento: {pessoaEscolhida.DataNascimento.ToShortDateString()}");
            Console.WriteLine($"Faltam {pessoaEscolhida.DiasParaProximoAniversario()} dias para o aniversário desta pessoa");
        }

        private static void ImprimirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("\nGerenciador de Aniversários\n");
        }

        private static void AdicionarPessoa()
        {
            ImprimirCabecalho();

            string nome = SolicitarEntrada.SolicitarStringAoUsuario("Digite o nome da pessoa que quer adicionar:");
            string sobrenome = SolicitarEntrada.SolicitarStringAoUsuario("Digite o sobrenome da pessoa que quer adicionar:");
            DateTime dataNascimento = SolicitarEntrada.SolicitarDataAoUsuario("Digite a data de nascimento no formato dd/MM/yyyy:");

            ImprimirCabecalho();

            Console.WriteLine("Os dados abaixo estão corretos?\n");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Sobrenome: {sobrenome}");
            Console.WriteLine($"Data de nascimento: {dataNascimento:dd/MM/yyyy}");

            Console.WriteLine("\n1- Sim");
            Console.WriteLine("2- Não");

            int opcao = SolicitarEntrada.SolicitarNumeroAoUsuario(string.Empty);
            switch(opcao)
            {
                case 1:
                    Pessoa pessoa = new Pessoa(nome, sobrenome, dataNascimento);
                    pessoaRepository.AdicionarPessoa(pessoa);
                    Console.WriteLine("Dados adicionados com sucesso!");
                    break;
                default:
                    AdicionarPessoa();
                    break;
            }
        }
    }
}
