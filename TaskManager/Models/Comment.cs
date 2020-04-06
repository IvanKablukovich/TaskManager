using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Models
{
    [Table("Comments")]
    public class Comment
    {
        [PrimaryKey, AutoIncrement]
        public int CommentId { get; set; }
        public string Field { get; set; }
        public string UserName { get; set; }

        [ForeignKey(typeof(Task))]
        public int IdTask { get; set; }

    }
}
