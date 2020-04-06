using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Models;

namespace TaskManager
{
    public class DBRepository
    {

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
            // conn.Table<Table_Users>().Where(L => L.Id == 2).Select(x=>x.User_Name);
            //return database.Table<Comment>().ToList();
            return database.Table<Comment>().Where(i => i.IdTask == id).ToList();
        }
        public Task GetItem(int id)
        {
            return database.Get<Task>(id);
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
                database.UpdateWithChildren(item);
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
