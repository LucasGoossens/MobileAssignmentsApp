using InleverenWeek4MobileDev.Database;
using InleverenWeek4MobileDev.Models.DTO;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Repositories
{
    public class MemberChallengeRepository
    {
        private readonly SQLiteConnection _connection;
        public string? statusMessage { get; set; }
        public MemberChallengeRepository()
        {
            _connection = new SQLiteConnection(
            Constants.DatabasePath,
            Constants.flags);
            _connection.CreateTable<MemberChallenge>();

        }
        public bool CheckIfSignedUp(int memberId, int challengeId)
        {
            return _connection.Table<MemberChallenge>()
                .Any(mc => mc.MemberId == memberId && mc.ChallengeId == challengeId && mc.SignedUp);
        }

        public void SignUp(int memberId, int challengeId)
        {
            var existingEntry = _connection.Table<MemberChallenge>()
                .FirstOrDefault(mc => mc.MemberId == memberId && mc.ChallengeId == challengeId);
            if (existingEntry == null)
            {
                _connection.Insert(new MemberChallenge
                {
                    MemberId = memberId,
                    ChallengeId = challengeId,
                    SignedUp = true
                });
            }
            else
            {
                existingEntry.SignedUp = true;
                _connection.Update(existingEntry);
                // dit werkt niet, maar zou niet moeten uitmaken. bij uitschrijven .Where gebruiken
            }
        }

        // wordt nu niet gebruikt maar misschien late rhandig
        public List<MemberChallenge> GetParticipantsByChallengeId(int challengeId)
        {
            return _connection.Table<MemberChallenge>().Where(c => c.ChallengeId == challengeId).ToList();
        }

        public List<int> GetAllSignedUpChallengesByUserId(int userId)
        {
            return _connection.Table<MemberChallenge>()
                .Where(mc => mc.MemberId == userId && mc.SignedUp)
                .Select(mc => mc.ChallengeId)
                .ToList();
        }
    }
}
