using GerenciadorAniversarios.Pessoa.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorAniversarios.Pessoa.Application.AutoMapper;
using GerenciadorAniversarios.Pessoa.Application.DTOs;
using GerenciadorAniversarios.Pessoa.Data;
using GerenciadorAniversarios.Pessoa.Data.Repository;
using Microsoft.Extensions.Hosting;
using AutoMapper;

namespace GerenciadorAniversarios.App.Console
{

    public class Program
    {
        IPessoaAppService _pessoaAppService;

        public Program(IPessoaAppService pessoaAppService)
        {
            _pessoaAppService = pessoaAppService;
        }

        public static async Task Main(string[] args)
        {
            // Create the service container
            var builder = new ServiceCollection()
                .AddSingleton<Program, Program>()
                .AddScoped<IPessoaRepository, PessoaRepository>()
                .AddScoped<IPessoaAppService, PessoaAppService>()
                .AddAutoMapper(typeof(PessoaDtoParaPessoaModel), typeof(PessoaModelParaPessoaDto))
                .BuildServiceProvider();

            int opcao = 0;
            IPessoaAppService pessoaAppService = builder.GetService<IPessoaAppService>();

            ExibeAniversariantesDoDia(pessoaAppService);

            while (opcao != 5)
            {
                ExibeMenu();

                opcao = SolicitarEntrada.SolicitarNumeroAoUsuario(string.Empty);

                switch (opcao)
                {
                    case 1:
                        AdicionarPessoa(pessoaAppService);
                        break;
                    case 2:
                        ConsultarPessoas(pessoaAppService);
                        break;
                    case 3:
                        AtualizarPessoa(pessoaAppService);
                        break;
                    case 4:
                        ApagarPessoa(pessoaAppService);
                        break;
                    case 5:
                        System.Console.WriteLine("Obrigada pela participação");
                        break;
                    default:
                        System.Console.WriteLine("Opção inválida!");
                        break;
                }

                System.Console.ReadLine();
            }
            
        }

        private static void ApagarPessoa(IPessoaAppService pessoaAppService)
        {
            var id = BuscarIdParaAcao(pessoaAppService);

            pessoaAppService.Apagar(id);

            System.Console.WriteLine("Pessoa apagada com sucesso!");
        }

        private static Guid BuscarIdParaAcao(IPessoaAppService pessoaAppService)
        {
            ImprimirCabecalho();
            ConsultarPessoas(pessoaAppService);

            var id = Guid.Parse(SolicitarEntrada.SolicitarStringAoUsuario(
                "Digite o código da pessoa que você deseja apagar"));

            return id;
        }

        private static void AtualizarPessoa(IPessoaAppService pessoaAppService)
        {
            Guid id = BuscarIdParaAcao(pessoaAppService);

            var nome = SolicitarEntrada.SolicitarStringAoUsuario("Digite o novo nome:");
            var sobrenome = SolicitarEntrada.SolicitarStringAoUsuario("Digite novo sobrenome:");
            var dataNascimento = SolicitarEntrada.SolicitarDataAoUsuario("Digite a nova data de nascimento no formato dd/MM/yyyy:");

            pessoaAppService.Atualizar(new PessoaDto()
            {
                Id = id,
                Nome = nome,
                Sobrenome = sobrenome,
                DataNascimento = dataNascimento
            });

            System.Console.WriteLine("Pessoa atualizada com sucesso!");
        }

        private async static void ConsultarPessoas(IPessoaAppService pessoaAppService)
        {
            ImprimirCabecalho();

            var nome = SolicitarEntrada.SolicitarStringAoUsuario("Digite o nome, ou parte do nome, da pessoa que deseja encontrar: ");

            var pessoasEncontradas = await pessoaAppService.BuscarPorNome(nome);

            foreach (var pessoaEncontrada in pessoasEncontradas)
            {
                System.Console.WriteLine(pessoaEncontrada + "\n");
            }
        }

        private static void AdicionarPessoa(IPessoaAppService pessoaAppService)
        {
            var nome = SolicitarEntrada.SolicitarStringAoUsuario("Digite o nome da pessoa que quer adicionar:");
            var sobrenome = SolicitarEntrada.SolicitarStringAoUsuario("Digite o sobrenome da pessoa que quer adicionar:");
            var dataNascimento = SolicitarEntrada.SolicitarDataAoUsuario("Digite a data de nascimento no formato dd/MM/yyyy:");

            pessoaAppService.Adicionar(new PessoaDto()
            {
                Nome = nome,
                Sobrenome = sobrenome,
                DataNascimento = dataNascimento
            });

            System.Console.WriteLine("Pessoa cadastrada com sucesso!");
        }

        private static void ExibeMenu()
        {
            ImprimirCabecalho();
            System.Console.WriteLine("Selecione uma das opções abaixo: ");
            System.Console.WriteLine("1- Adicionar pessoa");
            System.Console.WriteLine("2- Pesquisar pessoas");
            System.Console.WriteLine("3- Atualizar pessoa");
            System.Console.WriteLine("4- Apagar pessoa");
            System.Console.WriteLine("5- Sair");
        }

        private static void ImprimirCabecalho()
        {
            System.Console.Clear();
            System.Console.WriteLine("\nGerenciador de Aniversários\n");
        }

        private async static void ExibeAniversariantesDoDia(IPessoaAppService pessoaAppService)
        {
            var aniversariantesDoDia = await pessoaAppService.ObterAniversariantesDoDia(DateOnly.FromDateTime(DateTime.Now));

            if (aniversariantesDoDia.Any())
            {
                ImprimirCabecalho();
                System.Console.WriteLine("ANIVERSARIANTES DE HOJE");

                foreach (var pessoa in aniversariantesDoDia)
                {
                    System.Console.WriteLine(pessoa + "\n");
                }
            }
            else
            {
                System.Console.WriteLine("NENHUM ANIVERSARIANTE HOJE");
            }

            System.Console.ReadLine();
        }
    }
}