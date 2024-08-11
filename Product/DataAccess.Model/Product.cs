using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Product
    {
        // Unique 6-digit ID
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Id { get; set; }

        [Required] [StringLength(100)] public string Name { get; set; } = string.Empty;

        [Required] public int Quantity { get; set; }
    }
}