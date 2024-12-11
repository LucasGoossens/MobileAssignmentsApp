using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Models
{
    public class Comment
    {
        public int UserId { get; set; }
        public int SubmissionId { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public List<Comment> Replies { get; set; }
    }
}
