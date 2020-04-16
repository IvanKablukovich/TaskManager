using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Models;
using System.IO;

namespace TaskManager
{
    public class DBRepository
    {

        private static DBRepository instance;

        private DBRepository()
        { }

        public static DBRepository getInstance
        {
            get
            {
                if (instance == null)
                    instance = new DBRepository(Path.Combine(
                                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User1234.db"));
                return instance;
            }
        }

        SQLiteConnection database;
        public DBRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<User>();
            database.CreateTable<Task>();
            database.CreateTable<Comment>();
        }
        public IEnumerable<Task> GetTasks()
        {
            return database.Table<Task>().ToList();
        }
        public IEnumerable<Comment> GetComments(int id)
        {
            return database.Table<Comment>().Where(i => i.IdTask == id).ToList();
        }

        public IEnumerable<User> GetUserByName(string name)
        {
            return database.Table<User>().Where(u => u.Name.Equals(name));
        }

        public object CheckUser(string Name,string Password)
        { 
            return database.Table<User>().Where(u => u.Name.Equals(Name) && u.Password.Equals(Password)).FirstOrDefault();
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Task>(id);
        }
        public int SaveItem(User item)
        {
            if (item.UserId != 0)
            {
                database.Update(item);
                return item.UserId;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public int SaveTask(Task item)
        {
            if (item.TaskId != 0)
            {
                database.Update(item);
                return item.TaskId;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public int SaveComment(Comment item)
        {
            if (item.CommentId != 0)
            {
                database.Update(item);
                return item.CommentId;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
