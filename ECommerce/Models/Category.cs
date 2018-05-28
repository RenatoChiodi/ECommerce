using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "Categoria ID")]
        public int CategoryId { get; set; }

        [Display(Name = "Categoria")]
        [MaxLength(100, ErrorMessage = "O nome nao deve conter mais que 50 caracteres!!")]
        [Required(ErrorMessage = "O Campo Categoria é Obrigatório!")]
        [Index("Category_Description_CompanyId_Index",2, IsUnique = true)]
        public string Description { get; set; }


        [Display(Name = "Distribuidoras")]
        [Index("Category_Description_CompanyId_Index", 1, IsUnique = true)]
        [Range(1, Double.MaxValue, ErrorMessage = "Selecione uma Distribuidora!")]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}