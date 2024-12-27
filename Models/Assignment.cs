using InleverenWeek4MobileDev.Repositories;
using InleverenWeek4MobileDev.Session;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Models
{
    [Table("Assignments")]
    public class Assignment
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int ChallengeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Ignore]
        public int Number { get; set; }
        // dit is het nummer van de assigment ten opzichte van de lijst van alle assignments in een challenge,
        // wordt berekend in viewmodel omdat t dynamisch is, geen reden om op te slaan
        // gebeurt in AssignmentsViewmodel/LoadChallengeData();
        [Ignore]
        public Dictionary<string, string> Guides { get; set; }
        [Column("GuidesJson")]
        public string GuidesJson
        {
            get => Guides != null ? JsonSerializer.Serialize(Guides) : null;
            set => Guides = !string.IsNullOrEmpty(value) ? JsonSerializer.Deserialize<Dictionary<string, string>>(value) : null;
        }

        [Ignore]
        public List<Submission> Submissions { get; set; }
        
        public string Status { get; set; }
        // dit gaat over of assignment Locked, Unlocked of Completed is

        public void UnlockAssignment()
        {
            MemberAssignmentRepository memberAssignmentRepository = new MemberAssignmentRepository();
            memberAssignmentRepository.SetAssignmentStatus(UserSession.Instance.UserId, this.Id, "Unlocked");          
            
            UserRepository userRepository = new UserRepository();
            userRepository.AddOrUpdate(UserSession.Instance.LoggedInUser);

            UserSession.Instance.Initialize();           

        }

        public void SetHeaderImage()
        {
            // hier dan de image van de meest populaire submission als header?
        }
    }
}
