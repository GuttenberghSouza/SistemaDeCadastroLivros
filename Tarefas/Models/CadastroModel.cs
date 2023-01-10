using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarefas.Models
{
    [Table("Livro")]
    public class CadastroModel
    {
        [Column("Id")]
        [Display(Name = "Código")]

        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]

        public string Nome { get; set; }

        [Column("Informacao")]
        [Display(Name = "Informacao")]

        public string Informacao { get; set; }
    

        [Column("Autor")]
        [Display(Name = "Autor")]

        public string Autor { get; set; }
  

        [Column("Ano")]
        [Display(Name = "Ano")]
        public string Ano { get; set; }
    }
}
