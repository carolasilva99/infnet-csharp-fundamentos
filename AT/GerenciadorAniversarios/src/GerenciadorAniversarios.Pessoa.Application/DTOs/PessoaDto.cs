using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAniversarios.Pessoa.Application.DTOs
{
    public class PessoaDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateOnly DataNascimento { get; set; }
        public int DiasParaProximoAniversario { get; set; }
        public string NomeCompleto { get; set; }

        public override string ToString()
        {
            return $"Código: {Id}\n" + 
                   $"Nome: {NomeCompleto}\n" +
                   $"Data de nascimento: {DataNascimento}\n" +
                   $"Dias para o próximo aniversário: {DiasParaProximoAniversario}";
        }
    }
}
