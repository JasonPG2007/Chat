using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object
{
    public class Message
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MessageId { get; set; }
        [Display(Name = "Account ID")]
        public int AccountId { get; set; }
        public string Contents { get; set; }
        [Display(Name = "Date send")]
        public DateTime DateSend { get; set; }
        public virtual Account? Account { get; set; }
    }
}
