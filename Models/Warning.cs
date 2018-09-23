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
    public class Warning
    {
        [Column("Id"), PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("ParticipantId"), ForeignKey(typeof(Participant))]
        public int ParticipantId { get; set; }

        [Column("Participant")]
        public Participant Participant { get; set; }

        [Column("ResultId"), ForeignKey(typeof(Result))]
        public int ResultId { get; set; }

        [Column("Result")]
        public Result Result { get; set; }
    }
}
