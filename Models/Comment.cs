using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Models
{
    [Table("Comments")]
    public class Comment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int UserId { get; set; }
        [Indexed]
        public int SubmissionId { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }        
        [Ignore]
        public User User { get; set; }

        public Comment(){}
    }
}
