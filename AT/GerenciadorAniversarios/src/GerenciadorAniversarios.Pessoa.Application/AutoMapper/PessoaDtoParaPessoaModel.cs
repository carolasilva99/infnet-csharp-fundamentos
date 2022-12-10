using AutoMapper;
using GerenciadorAniversarios.Pessoa.Application.DTOs;

namespace GerenciadorAniversarios.Pessoa.Application.AutoMapper
{
    public class PessoaDtoParaPessoaModel : Profile
    {
        public PessoaDtoParaPessoaModel()
        {
            CreateMap<PessoaDto, Domain.Pessoa>();
        }
        
    }
}
