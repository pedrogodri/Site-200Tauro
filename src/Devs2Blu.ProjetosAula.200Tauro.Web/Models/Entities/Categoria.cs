using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Devs2Blu.ProjetosAula._200Tauro.Web.Models.Entities
{
    public class Categoria
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        public ICollection<Conteudo>? Conteudos { get; set; }
    }
}
