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
        [Column("FirstName")]
        public string FirstName { get; set; }
        [Column("LastName")]
        public string LastName { get; set; }
        [Column("YearOfBirth")]
        public int YearOfBirth { get; set; }
        [Column("GenderId")]
        public int GenderId { get; set; }
        [Column("Gender"), ManyToOne]
        public Gender Gender { get; set; }
        [Column("CatId"), ForeignKey(typeof(Category))]
        public int CategoryId { get; set; }
        [Column("Category"), ManyToOne]
        public Category Category { get; }
        [Column("Results"), OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Result> Results { get; set; }
        [Column("StateId"), ForeignKey(typeof(State))]
        public int StateId { get; set; }
        [Column("State"), ManyToOne]
        public State State { get; set; }
        [Column("Warnings"), OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Warning> Warnings { get; set; }
    }
}
