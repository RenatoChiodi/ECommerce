using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ECommerce.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "O Campo E-mail é Obrigatório!")]
        [Display(Name = "E-mail")]
        [MaxLength(250, ErrorMessage = "O E-mail nao deve conter mais que 250 caracteres!!")]
        [Index("User_UserName_Index", IsUnique = true)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O Campo Nome é Obrigatório!")]
        [Display(Name = "Nome")]
        [MaxLength(50, ErrorMessage = "O nome nao deve conter mais que 50 caracteres!!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O Campo Sobrenome é Obrigatório!")]
        [Display(Name = "Sobrenome")]
        [MaxLength(50, ErrorMessage = "O Sobrenome nao deve conter mais que 50 caracteres!!")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "O Campo Telefone é Obrigatório!")]
        [Display(Name = "Telefone")]
        [MaxLength(50, ErrorMessage = "O nome nao deve conter mais que 50 caracteres!!")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O Campo Endereço é Obrigatório!")]
        [Display(Name = "Endereço")]
        [MaxLength(100, ErrorMessage = "O nome nao deve conter mais que 50 caracteres!!")]
        public string Address { get; set; }


        [Display(Name = "Imagem")]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [NotMapped]
        public HttpPostedFileBase PhotoFile { get; set; }

        [Required(ErrorMessage = "O Campo Departamento é Obrigatório!")]
        [Display(Name = "Departamento")]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage = "O Campo Cidade é Obrigatório!")]
        [Display(Name = "Cidade")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "O Campo Companhia é Obrigatório!")]
        [Display(Name = "Companhia")]
        public int CompanyId { get; set; }

        [Display(Name = "Usuario")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public virtual Departaments Departaments { get; set; }

        public virtual City Cities { get; set; }

        public virtual Company Company { get; set; }


    }
}