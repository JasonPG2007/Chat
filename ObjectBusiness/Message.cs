using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBusiness
{
    public class Message
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MessageId { get; set; }
        [Display(Name = "Account send")]
        public int AccountId { get; set; }
        [Display(Name = "Account Receive")]
        public int AccountReceive { get; set; }
        public string Contents { get; set; }
        [Display(Name = "Date send")]
        public DateTime DateSend { get; set; } = DateTime.Now;
        public virtual Account? Account { get; set; }

        #region View Model
        [NotMapped]
        public string UserName { get; set; }
        [NotMapped]
        public string Avatar { get; set; }
        #endregion
    }
}
