using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Company
    {
        [Key]
        [Display(Name = "Compania")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "O Campo Nome é Obrigatório!")]
        [Display(Name = "Nome")]
        [MaxLength(50, ErrorMessage = "O nome nao deve conter mais que 50 caracteres!!")]
        //[Index("Departaments_Name_Index", IsUnique = true)]
        public string Name { get; set; }


        [Required(ErrorMessage = "O Campo Telefone é Obrigatório!")]
        [Display(Name = "Telefone")]
        [MaxLength(50, ErrorMessage = "O nome nao deve conter mais que 50 caracteres!!")]
       // [Index("Departaments_Name_Index", IsUnique = true)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O Campo Endereço é Obrigatório!")]
        [Display(Name = "Endereço")]
        [MaxLength(100, ErrorMessage = "O nome nao deve conter mais que 50 caracteres!!")]       
        public string Address { get; set; }

       
        [Display(Name = "Imagem")]
        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        
        [Required(ErrorMessage = "O Campo Departamento é Obrigatório!")]
        [Display(Name = "Departamento")]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage = "O Campo Cidade é Obrigatório!")]
        [Display(Name = "Cidade")]
        public int CityId { get; set; }

        public virtual Departaments Departaments { get; set; }
        public virtual City Cities { get; set; }
       
       
    }
}