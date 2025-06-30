using System.Text.Json.Serialization;
using Microsoft.VisualBasic;

namespace Treinamento.Web.Models
{
    public class Linguagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [JsonIgnore] // <-- ADICIONE ESTE ATRIBUTO
        public ICollection<Informacao> Informacoes { get; set; }
    }
}