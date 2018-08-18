using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Models
{
    public class Result
    {
        [Column("Id"), PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("PartId"), ForeignKey(typeof(Participant))]
        public int ParticipantId { get; set; }
        [Column("DiscId"), ForeignKey(typeof(Discipline))]
        public int DisciplineId { get; set; }
        [Column("Value")]
        public decimal Value { get; set; }
        [Column("Points")]
        public decimal Points { get; set; }

    }
}
