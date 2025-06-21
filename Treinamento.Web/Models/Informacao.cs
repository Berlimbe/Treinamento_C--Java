namespace Treinamento.Web.Models
{
    public class Informacao
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }

        public int LinguagemId { get; set; }

        public Linguagem Linguagem { get; set; }
    }
}