using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Models
{
    public class Challenge
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Assignment> Assignments { get; set; }
        public Supermember Creator { get; set; }
        public List<Member> Participants { get; set; }

    }
}
