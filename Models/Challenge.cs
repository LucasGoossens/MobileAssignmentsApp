using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Models
{
    [Table("Challenges")]
    public class Challenge
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("title"), Indexed, NotNull]
        public string? Title { get; set; }
        public string? ImageSource { get; set; }
        public string Description { get; set; }
        [Ignore]        
        public int CreatorId { get; set; }
        [Ignore]
        public List<Assignment> Assignments { get; set; }
        [Ignore]
        public Supermember Creator { get; set; }
        [Ignore]
        public List<Member> Participants { get; set; }

    }
}
