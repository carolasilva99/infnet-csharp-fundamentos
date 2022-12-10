using AutoMapper;
using GerenciadorAniversarios.Pessoa.Application.DTOs;

namespace GerenciadorAniversarios.Pessoa.Application.AutoMapper
{
    public class PessoaModelParaPessoaDto : Profile
    {
        public PessoaModelParaPessoaDto()
        {
            CreateMap<Domain.Pessoa, PessoaDto>()
                .ForMember(dest => dest.DiasParaProximoAniversario,
                    opts => opts.MapFrom(src => src.DiasParaProximoAniversario()))
                .ForMember(dest => dest.NomeCompleto,
                    opts => opts.MapFrom(src => src.MontarNomeCompleto()));
        }
        
    }
}
