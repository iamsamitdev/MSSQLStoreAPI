using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSSQLStoreAPI.Models
{
    [Table("Products", Schema = "dbo")]
    [Comment("ตารางไว้เก็บข้อมูลสินค้า")]
    public class Products
    {
        [Key]
        public int ProductID {get; set;}

        [Required]
        [Column(TypeName = "varchar(64)", Order = 1)]
        public string ProductName {get; set;}

        [Required]
        [Column(TypeName = "decimal(10, 2)", Order = 2)]
        public decimal UnitPrice {get; set;}

        [Required]
        [Column(Order = 3)]
        public int UnitInStock {get; set;}

        [Required]
        [Column(TypeName = "varchar(128)", Order = 4)]
        public string ProductPicture {get; set;}

        [Column(Order = 5)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column(Order = 6)]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        [ForeignKey("CategoryInfo")]
        public int CategoryId {get; set;}
        public virtual Category CategoryInfo {get; set;}

        [NotMapped]
        public string CategoryName {get; set;}

    }
}