using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public static class Interface
    {
        public static void LimparTela()
        {
            Console.Clear();
        }

        public static void ImprimirCabecalho()
        {
            LimparTela();
            Console.WriteLine("Gerenciador de Aniversários\n");
        }

        public static void ImprimirMenu()
        {
            ImprimirCabecalho();
            Console.WriteLine("Selecione uma das opções abaixo\n");
            Console.WriteLine("1- Adicionar novo amigo");
            Console.WriteLine("2- Consultar um amigo");
            Console.WriteLine("3- Alterar um amigo");
            Console.WriteLine("4- Apagar um amigo");
            Console.WriteLine("5- Sair");
        }

        public static void ImprimirEAguardarEnter(string mensagem)
        {
            Console.WriteLine(mensagem);
            Console.ReadKey();
        }

        public static void Imprimir(string mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }
}
