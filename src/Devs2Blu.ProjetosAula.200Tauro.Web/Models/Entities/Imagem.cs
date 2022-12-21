using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Devs2Blu.ProjetosAula._200Tauro.Web.Models.Entities
{
    public class Imagem
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Conteúdo")]
        public int ConteudoId { get; set; }


        [Display(Name = "Imagem")]
        public string EnderecoImagem { get; set; }

        public virtual Conteudo Conteudo { get; set; }
    }
}
