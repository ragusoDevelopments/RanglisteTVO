using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Models
{
    public class State
    {
        [Column("Id"), PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; } = true;
    }
}
