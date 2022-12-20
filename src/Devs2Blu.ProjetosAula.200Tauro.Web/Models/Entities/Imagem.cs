using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Devs2Blu.ProjetosAula._200Tauro.Web.Models.Entities
{
    [Table("imagem")]
    public class Imagem
    {
        [Display(Name = "Código")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Conteúdo")]
        [Column("ConteudoId")]
        public int ConteudoID { get; set; }


        [Display(Name = "Imagem")]
        [Column("EnderecoImagem")]
        public string EnderecoImagem { get; set; }

        public virtual Conteudo Conteudo { get; set; }
    }
}
