using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Tax
    {
        [Key]
        [Display(Name = "Taxa ID")]
        public int TaxId { get; set; }

        [Display(Name = "Imposto")]
        [MaxLength(100, ErrorMessage = "O nome nao deve conter mais que 50 caracteres!!")]
        [Required(ErrorMessage = "O Campo Categoria é Obrigatório!")]
        //[Index("Category_Description_CompanyId_Index", 2, IsUnique = true)]
        public string Description { get; set; }

        [Display(Name = "Imposto")]
        [Required(ErrorMessage = "O Campo Imposto é Obrigatório!")]
        //[Range(0,1,  ErrorMessage = "Apenas valores de 0 à 1!")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public float Rate { get; set; }


        [Display(Name = "Distribuidoras")]
        //[Index("Category_Description_CompanyId_Index", 1, IsUnique = true)]
        [Range(1, Double.MaxValue, ErrorMessage = "Selecione uma Distribuidora!")]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Produtc> Product { get; set; }
    }
}