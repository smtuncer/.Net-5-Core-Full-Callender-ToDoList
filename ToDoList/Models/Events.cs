using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Events
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string color { get; set; }
        public string textColor { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
