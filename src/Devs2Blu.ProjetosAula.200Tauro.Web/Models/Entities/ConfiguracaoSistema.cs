using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Devs2Blu.ProjetosAula._200Tauro.Web.Models.Entities
{
    public class ConfiguracaoSistema
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nome site")]
        public string NomeSite { get; set; }

        [Display(Name = "Contato")]
        public string Contato { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
    }
}
