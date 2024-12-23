using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Models
{
    [Table("Submissions")]
    public class Submission
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int CreatorId { get; set; }        
        [Indexed]
        public string Image { get; set; }
        public int Likes { get; set; }
        [Ignore]
        public User Creator { get; set; }
        [Ignore]
        public List<Comment> Comments { get; set; }

    }
}
