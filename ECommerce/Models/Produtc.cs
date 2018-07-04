using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ECommerce.Models
{
    public class Produtc
    {
        [Key]
        [Display(Name = "Produto ID")]
        public int ProductId { get; set; }

        [Display(Name = "Distribuidoras")]
        [Index("Product_Description_CompanyId_Index", 1, IsUnique = true)]
        [Index("Product_BarCode_CompanyId_Index", 1, IsUnique = true)]
        [Required(ErrorMessage = "O Campoo Distribuidoras é Obrigatório!")]
        [Range(1, Double.MaxValue, ErrorMessage = "Selecione uma Distribuidora!")]
        public int CompanyId { get; set; }

        [Display(Name = "Produto")]
        [MaxLength(100, ErrorMessage = "O nome nao deve conter mais que 50 caracteres!!")]
        [Required(ErrorMessage = "O Campo Categoria é Obrigatório!")]
        [Index("Product_Description_CompanyId_Index", 2, IsUnique = true)]
        public string Description { get; set; }

        [Display(Name = "Codigo de Barras")]
        [MaxLength(100, ErrorMessage = "O Codigo de barras nao deve conter mais que 50 caracteres!!")]
        [Required(ErrorMessage = "O Campo codigo de barras é Obrigatório!")]
        [Index("Product_BarCode_CompanyId_Index", 2, IsUnique = true)]
        public string BarCode { get; set; }


        [Required(ErrorMessage = "O Campoo Taxa é Obrigatório!")]
        [Range(1, Double.MaxValue, ErrorMessage = "Selecione uma Taxa!")]
        [Display(Name = "Taxa")]
        public int TaxId { get; set; }

        [Required(ErrorMessage = "O Campoo Categoria é Obrigatório!")]
        [Range(1, Double.MaxValue, ErrorMessage = "Selecione uma Categoria!")]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O Campo Valor é Obrigatório!")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }


        [Display(Name = "Imagem")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


        [Display(Name = "Codigo de Barras")]
        [DataType(DataType.MultilineText)]

        public string Remarks { get; set; }



        public virtual Company Company { get; set; }
        public virtual Tax Tax { get; set; }
        public virtual Category Category { get; set; }
    }
}