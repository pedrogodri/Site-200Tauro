using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Devs2Blu.ProjetosAula._200Tauro.Web.Models.Entities
{
    public class Newsletter
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
    }
}
