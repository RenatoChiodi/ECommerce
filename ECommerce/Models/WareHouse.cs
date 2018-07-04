using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class WareHouse
    {
        [Key]
        [Display(Name = "Armazem ID")]
        public int WareHouseId { get; set; }

        [Required(ErrorMessage = "O Campo Companhia é Obrigatório!")]
        [Display(Name = "Companhia")]
        [Index("WareHouse_CompanyId_Name_Index", 1, IsUnique = true)]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "O Campo Armazem é Obrigatório!")]
        [Display(Name = "Armazem")]
        [MaxLength(250, ErrorMessage = "O Armazem nao deve conter mais que 250 caracteres!!")]
        [Index("WareHouse_CompanyId_Name_Index", 2, IsUnique = true)]
        public string Name { get; set; }

        
        [Required(ErrorMessage = "O Campo Telefone é Obrigatório!")]
        [Display(Name = "Telefone")]
        [MaxLength(50, ErrorMessage = "O nome nao deve conter mais que 50 caracteres!!")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O Campo Endereço é Obrigatório!")]
        [Display(Name = "Endereço")]
        [MaxLength(100, ErrorMessage = "O nome nao deve conter mais que 50 caracteres!!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "O Campo Departamento é Obrigatório!")]
        [Display(Name = "Departamento")]
        public int DepartamentId { get; set; }

        [Required(ErrorMessage = "O Campo Cidade é Obrigatório!")]
        [Display(Name = "Cidade")]
        public int CityId { get; set; }

       public virtual Departaments Departaments { get; set; }

        public virtual City Cities { get; set; }

        public virtual Company Company { get; set; }

    }
}