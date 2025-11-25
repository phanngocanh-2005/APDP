using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthApp.Models
{
    [Table("account")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Fullname { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Password { get; set; }

        public ICollection<TaskJob>? Tasks { get; set; }

    }
}
