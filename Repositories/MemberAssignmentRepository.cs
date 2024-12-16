using InleverenWeek4MobileDev.Models.DTO;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Repositories
{
    public class MemberAssignmentRepository
    {
        private readonly SQLiteConnection _connection;

        public MemberAssignmentRepository(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<MemberAssignment>();
        }

        public List<MemberAssignment> GetAssignmentsByStatus(int memberId, string status)
        {
            return _connection.Table<MemberAssignment>()
                .Where(ma => ma.MemberId == memberId && ma.Status == status)
                .ToList();
        }

        public void SetAssignmentStatus(int memberId, int assignmentId, string status)
        {
            var existingEntry = _connection.Table<MemberAssignment>()
                .FirstOrDefault(ma => ma.MemberId == memberId && ma.AssignmentId == assignmentId);

            if (existingEntry == null)
            {
                _connection.Insert(new MemberAssignment
                {
                    MemberId = memberId,
                    AssignmentId = assignmentId,
                    Status = status
                });
            }
            else
            {
                existingEntry.Status = status;
                _connection.Update(existingEntry);
            }
        }
    }

}
