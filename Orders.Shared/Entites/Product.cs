﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace Orders.Shared.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Description { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Display(Name = "Inventario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public float Stock { get; set; }

        public ICollection<ProductCategory>? ProductCategories { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }

        [Display(Name = "Categorías")]
        public int ProductCategoriesNumber => ProductCategories == null || ProductCategories.Count == 0 ? 0 : ProductCategories.Count;

        public ICollection<ProductImage>? ProductImages { get; set; }

        [Display(Name = "Imágenes")]
        public int ProductImagesNumber => ProductImages == null || ProductImages.Count == 0 ? 0 : ProductImages.Count;

        public ICollection<TemporalOrder>? TemporalOrders { get; set; }

        [Display(Name = "Imagen")]
        public string MainImage => ProductImages == null || ProductImages.Count == 0
    ? $"https://localhost:7225/images/products/noimage.png"
    : $"https://localhost:7225{ProductImages.FirstOrDefault()!.Image[1..]}";

    }
}
