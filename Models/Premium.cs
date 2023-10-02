using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TesteHenrique.Models
{
    public class Premium
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o titulo do premium")]
        [StringLength(100, ErrorMessage = "O titulo deve conter 100 caracteres")]
        [MinLength(4, ErrorMessage = "O titulo deve conter pelo menos 5 caracteres")]
        [DisplayName("Titulo")]
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        [DisplayName("Inicio")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Termino")]
        public DateTime? EndDate { get; set; }

        [DisplayName("Aluno")]
        [Required(ErrorMessage = "Aluno Invalido")]
        public string StudentId { get; set; } = string.Empty;

        public Student? Student { get; set; }
    }
}
