using SQLite;

namespace InleverenWeek4MobileDev.Models.DTO
{
    [Table("MemberChallenge")]
   public class MemberChallenge
    {        
        [Indexed]       
        public int MemberId { get; set; }

        [Indexed]
        public int ChallengeId { get; set; }

        public bool SignedUp { get; set; }  
    }
}
