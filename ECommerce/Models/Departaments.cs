using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Departaments
    {
        [Key]
        [Display(Name = "Departamento")]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage ="O Campo Nome é Obrigatório!")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}