using Microsoft.VisualBasic;

namespace Treinamento.Web.Models
{
    public class Linguagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Informacao> Informacoes { get; set; }
    }
}