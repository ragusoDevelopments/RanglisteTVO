using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;

namespace Models
{
    public class DisciplineValue
    {
        [Column("Id"), PrimaryKey, AutoIncrement]
        public int Id { get; }
        [Column("DiscId"), ForeignKey(typeof(Category)), ManyToOne]
        public int DisciplineId { get; set; }
        [Column("Gender")]
        public string Gendr { get; set; }
        [Column("Value")]
        public decimal Value { get; set; }
        [Column("Points")]
        public decimal Points { get; set; }
    }
}
