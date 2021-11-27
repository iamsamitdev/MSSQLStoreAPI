using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSSQLStoreAPI.Models
{
    [Table("Category", Schema = "dbo")]
    [Comment("ตารางไว้เก็บรายชื่อหมวดหมู่สินค้า")]
    public class Category
    {
        public int CategoryId {get; set;} // กำหนด PK แบบที่ 1

        // [Column("CategoryId")]
        // public int Id {get; set;} // กำหนด PK แบบที่ 2

        // [Key]
        // [Column("CategoryId")]
        // public int CategoryNumber {get; set;} // กำหนด PK แบบที่ 3

        [Required]
        [Column("CategoryName", TypeName = "varchar(64)", Order = 1)]
        public string CategoryName {get; set;}

        [Required]
        [Column(Order = 2)]
        public int CategoryStatus {get; set;}
    }
}