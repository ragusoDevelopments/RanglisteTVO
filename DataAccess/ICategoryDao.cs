using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccess
{
    public interface ICategoryDao
    {
        List<Category> GetAllCategories();

        void InsertCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
