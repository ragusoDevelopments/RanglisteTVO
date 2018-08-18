using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Models
{
    public class Discipline
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; }
        [Column("Name")]
        public string Name { get; set; }
        [OneToMany(CascadeOperations =CascadeOperation.All)]
        public List<DisciplineValue> Values { get; set; }
    }
}
