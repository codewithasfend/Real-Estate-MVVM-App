using Android.Print;
using RealEstateApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Services
{
    internal class BookmarkItemService
    {
        private readonly SQLiteConnection _database;
        public BookmarkItemService()
        {

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "entities.db");
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<BookmarkedProperty>();
        }

        public BookmarkedProperty Read(int id)
        {
           return _database.Table<BookmarkedProperty>().Where(p=>p.PropertyId == id).FirstOrDefault();
        }

        public List<BookmarkedProperty> ReadAll()
        {
            return _database.Table<BookmarkedProperty>().ToList();
        }

        public void Create(BookmarkedProperty bookmarkedProperty)
        {
            _database.Insert(bookmarkedProperty);   
        }

        public void Delete(BookmarkedProperty bookmarkedProperty)
        {
            _database.Delete(bookmarkedProperty);
        }

    }
}
