﻿using InteracaoUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subtracao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero1;
            int numero2;
            int resultado;

            numero1 = SolicitarEntrada.SolicitarNumeroAoUsuario("Digite o número 1: ");
            numero2 = SolicitarEntrada.SolicitarNumeroAoUsuario("Digite o número 2: ");

            resultado = numero1 - numero2;

            Console.WriteLine($"{numero1} - {numero2} = {resultado}");
            Console.WriteLine("Pressione qualquer tecla para sair");
            Console.ReadLine();
        }
    }
}
