using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteracaoUsuario
{
    public class SolicitarEntrada
    {
        public static int SolicitarNumeroAoUsuario(string mensagem)
        {
            string numero = string.Empty;

            try
            {
                Console.WriteLine(mensagem);
                numero = Console.ReadLine() ?? string.Empty;
                int result = Int32.Parse(numero);
                return result;
            }
            catch (Exception)
            {
                throw new ArgumentException($"Número inválido! '{numero}'");
            }
        }
    }
}
