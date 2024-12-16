using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Models.DTO
{
    [Table("MemberAssignments")]
    public class MemberAssignment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int MemberId { get; set; }

        [Indexed]
        public int AssignmentId { get; set; }

        public string Status { get; set; } // Locked, Unlocked, Completed
    }
}

