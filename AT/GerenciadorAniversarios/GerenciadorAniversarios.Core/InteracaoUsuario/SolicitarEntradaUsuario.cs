using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAniversarios.Core.InteracaoUsuario
{
    public class SolicitarEntradaUsuario
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

        public static string SolicitarStringAoUsuario(string mensagem)
        {
            string campo = string.Empty;

            try
            {
                Console.WriteLine(mensagem);
                campo = Console.ReadLine() ?? string.Empty;

                return campo;
            }
            catch (Exception)
            {
                throw new ArgumentException($"Campo inválido! '{campo}'");
            }
        }

        public static DateTime SolicitarDataAoUsuario(string mensagem)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string dataString = string.Empty;

            try
            {
                Console.WriteLine(mensagem);
                dataString = Console.ReadLine() ?? string.Empty;
                DateTime data = DateTime.ParseExact(dataString, "dd/MM/yyyy", provider);
                return data;
            }
            catch (Exception)
            {
                throw new ArgumentException($"Data inválida! '{dataString}'");
            }
        }
    }
}
