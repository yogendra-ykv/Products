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

        [Required] public string Name { get; set; }
        [Required] public int Quantity { get; set; }
    }
}