using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthApp.Models
{
    [Table("tasks")]
    public class TaskJob
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [Required]
        public int AccountId { get; set; }

        public Category? Category { get; set; }
        public Account? Account { get; set; }
    }
}
