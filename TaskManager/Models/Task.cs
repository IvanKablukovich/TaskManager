﻿using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Models
{
    [Table("Tasks")]
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Created_by { get; set; }
        public string Image { get; set; }
        public string ImageName { get; set; }
        public string File { get; set; }
        public string FileName { get; set; }
        [OneToMany]
        public List<Comment> Comments { get; set; }

    }
}
