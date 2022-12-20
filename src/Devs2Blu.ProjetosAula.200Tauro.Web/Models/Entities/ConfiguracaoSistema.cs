using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Devs2Blu.ProjetosAula._200Tauro.Web.Models.Entities
{
    [Table("configuracaosistema")]
    public class ConfiguracaoSistema
    {
        [Display(Name = "Código")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Nome site")]
        [Column("NomeSite")]
        public string NomeSite { get; set; }

        [Display(Name = "Contato")]
        [Column("Contato")]
        public string Contato { get; set; }

        [Display(Name = "Endereço")]
        [Column("Endereco")]
        public string Endereco { get; set; }
    }
}
