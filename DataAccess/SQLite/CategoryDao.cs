using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace DataAccess.SQLite
{
    public class CategoryDao : ICategoryDao
    {
        DBHandler dbhandler = new DBHandler();
        SQLiteConnection conn;
        
        public List<Category> GetAllCategories()
        {
            conn = dbhandler.GetConnection();
            List<Category> c = conn.GetAllWithChildren<Category>();
            conn.Close();

            return c;
        }

        public void InsertCategory(Category category)
        {
            conn = dbhandler.GetConnection();
            conn.InsertWithChildren(category);
            conn.Close();
        }

        public void UpdateCategory(Category category)
        {
            conn = dbhandler.GetConnection();
            conn.UpdateWithChildren(category);
            conn.Close();
        }

        public void DeleteCategory(Category category)
        {
            conn = dbhandler.GetConnection();
            conn.Delete(category);
            conn.Close();
        }
    }
}
