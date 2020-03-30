using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Tables
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int UserId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
    [Table("Tasks")]
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Created_by { get; set; }
        [OneToMany]
        public List<Comment> Comments { get; set; }

    }

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
