using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nba.Core.Models.Entites
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        [StringLength(32)]
        public string UserName { get; set; }
        [StringLength(256)]
        public string Password { get; set; }
    }
}
