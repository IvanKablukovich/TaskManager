using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Tables;

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
        public IEnumerable<Task> GetItems()
        {
            return database.Table<Task>().ToList();
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
    }
}
