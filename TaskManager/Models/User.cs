using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Models
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }

        [Unique]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Role { get; set; }

    }
}
