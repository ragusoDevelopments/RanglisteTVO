using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions;

namespace Models
{
    public class Category
    {
        [Column("Id"), PrimaryKey, AutoIncrement]
        public int Id { get; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("MinAge")]
        public int MinAge { get; set; }
        [Column("MaxAge")]
        public int MaxAge { get; set; }

    }
}
