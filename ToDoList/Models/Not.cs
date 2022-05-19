using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class Not
    {
        [Key]
        public int NotId { get; set; }
        public string NotBasligi { get; set; }
        public string NotAciklamasi { get; set; }
        public string NotRengi { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
