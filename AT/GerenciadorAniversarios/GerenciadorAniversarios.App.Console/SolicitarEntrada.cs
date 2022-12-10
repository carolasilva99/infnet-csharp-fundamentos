using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAniversarios.App.Console
{
    public class SolicitarEntrada
    {
        public static int SolicitarNumeroAoUsuario(string mensagem)
        {
            string numero = string.Empty;

            try
            {
                System.Console.WriteLine(mensagem);
                numero = System.Console.ReadLine() ?? string.Empty;
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
                System.Console.WriteLine(mensagem);
                campo = System.Console.ReadLine() ?? string.Empty;

                return campo;
            }
            catch (Exception)
            {
                throw new ArgumentException($"Campo inválido! '{campo}'");
            }
        }

        public static DateOnly SolicitarDataAoUsuario(string mensagem)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string dataString = string.Empty;

            try
            {
                System.Console.WriteLine(mensagem);
                dataString = System.Console.ReadLine() ?? string.Empty;
                DateOnly data = DateOnly.ParseExact(dataString, "dd/MM/yyyy", provider);
                return data;
            }
            catch (Exception)
            {
                throw new ArgumentException($"Data inválida! '{dataString}'");
            }
        }
    }
}
