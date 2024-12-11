using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Models
{
    public class Submission
    {

        public int Id { get; set; }
        public User Creator { get; set; }
        public string Image { get; set; }
        public int Likes { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
