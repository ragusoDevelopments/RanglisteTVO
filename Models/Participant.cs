using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using SQLite;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace Models
{
    public class Participant
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; }
        [Column("StartNumber"), Unique, AutoIncrement]
        public int StartNumber { get; set; }
        [Column("FirstName")]
        public string FirstName { get; set; }
        [Column("LastName")]
        public string LastName { get; set; }
        [Column("YearOfBirth")]
        public int YearOfBirth { get; set; }
        [Column("Gender")]
        public string Gender { get; set; }
        [Column("CatId"), ForeignKey(typeof(Category))]
        public int CategoryId { get; set; }
        [Column("Category"), ManyToOne]
        public Category Category { get; }
        [Column("Results"), OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Result> Results { get; set; }
    }
}
