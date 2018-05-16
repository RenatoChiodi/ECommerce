using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class City
    {
        [Key]
        [Display(Name = "Cidade ID")]
        public int CityId { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "O Campo Nome é Obrigatório!")]
        public string Name { get; set; }


        [Display(Name = "Departamento")]
        [Range(1,Double.MaxValue, ErrorMessage ="Selecione um Departamento!")]
        public int DepartamentsId { get; set; }

        public virtual Departaments Departament { get; set; }
        public virtual ICollection<Company> Company { get; set; }
    }
}