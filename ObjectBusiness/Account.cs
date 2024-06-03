using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ObjectBusiness
{
    public class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccountId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Type { get; set; } = "Normal"; // VIP or Normal
        public int Point { get; set; }
        public DateTime DateRegister { get; set; }
        public virtual ICollection<Message>? Message { get; set; }
    }
}
