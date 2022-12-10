using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GerenciadorAniversarios.Pessoa.Domain
{
    public class GuidConverter : JsonConverter<Guid>
    {
        public GuidConverter()
        {
        }

        public override void WriteJson(JsonWriter writer, Guid value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString("N"));
        }

        public override Guid ReadJson(JsonReader reader, Type objectType, Guid existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string value = reader.Value.ToString();
            return Guid.Parse(value);
        }

        public override bool CanRead
        {
            get { return true; }
        }

    }
}
