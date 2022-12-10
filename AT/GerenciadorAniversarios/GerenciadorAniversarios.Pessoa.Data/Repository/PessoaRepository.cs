using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorAniversarios.Pessoa.Data.Repository;
using GerenciadorAniversarios.Pessoa.Domain;
using Newtonsoft.Json;

namespace GerenciadorAniversarios.Pessoa.Data
{
    public class PessoaRepository : IPessoaRepository
    {
        private string _diretorioPessoas = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "pessoas");

        public PessoaRepository()
        {
            CriarPastaPadrao();
        }

        private void CriarPastaPadrao()
        {
            Directory.CreateDirectory(_diretorioPessoas);
        }

        public async Task<IEnumerable<Domain.Pessoa>> ObterTodas()
        {
            var arquivos = BuscarTodosArquivos();
            var pessoas = BuscarPessoasArquivos(arquivos);

            return pessoas;
        }

        public async Task<Domain.Pessoa> ObterPorId(Guid id)
        {
            var pessoaJson = File.ReadAllText(ArquivoPessoaPath(id));
            return JsonConvert.DeserializeObject<Domain.Pessoa>(pessoaJson);
        }

        private string ArquivoPessoaPath(Guid id)
        {
            return $"{_diretorioPessoas}{Path.DirectorySeparatorChar}{id}.json";
        }

        public void Adicionar(Domain.Pessoa pessoa)
        {
            var pessoaJson = JsonConvert.SerializeObject(pessoa);
            var path = ArquivoPessoaPath(pessoa.Id);
            File.WriteAllText(path, pessoaJson);
        }

        public void Atualizar(Domain.Pessoa pessoa)
        {
            Adicionar(pessoa);
        }

        public void Apagar(Guid id)
        {
            File.Delete(ArquivoPessoaPath(id));
        }

        private IEnumerable<string> BuscarTodosArquivos()
        {
            var arquivosEncontrados = Directory.EnumerateFiles(_diretorioPessoas, "*", SearchOption.AllDirectories);

            return (from arquivo 
                in arquivosEncontrados 
                let extension = Path.GetExtension(arquivo) 
                where extension == ".json" 
                select arquivo).ToList();
        }

        private IEnumerable<Domain.Pessoa> BuscarPessoasArquivos(IEnumerable<string> arquivos)
        {
            var pessoas = new List<Domain.Pessoa>();

            foreach (var arquivo in arquivos)
            {
                var pessoaJson = File.ReadAllText(arquivo);
                var data = JsonConvert.DeserializeObject<Domain.Pessoa?>(pessoaJson);

                if (data != null)
                    pessoas.Add(data);
            }

            return pessoas;
        }
    }
}
