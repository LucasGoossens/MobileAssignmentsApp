using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public int ChallengeId { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Guides { get; set; }
        public List<Submission> Submissions { get; set; }

    }
}
