using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Devs2Blu.ProjetosAula._200Tauro.Web.Models.Entities
{
    [Table("conteudo")]
    public class Conteudo
    {
        [Display(Name = "Código")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Título")]
        [Column("Titulo")]
        public string Titulo { get; set; }
        
        [Display(Name = "Descrição")]
        [Column("Descricao")]
        public string Descricao { get; set; }

        [Display(Name = "Categoria")]
        [Column("CategoriaId")]
        public int CategoriaId{ get; set; }

        public virtual Categoria Categoria{ get; set; }

        [Column("IsPublished")]
        public bool IsPublished{ get; set; }

        [Column("IsDeleted")]
        public bool IsDeleted{ get; set; }

        [Column("CreatedDate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:MM/dd/yyyy}")]
        public DateTime CreatedDate{ get; set; }
        public virtual ICollection<Imagem> Imagens{ get; set; }


    }
}
