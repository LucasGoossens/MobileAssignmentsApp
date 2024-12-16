using InleverenWeek4MobileDev.Database;
using InleverenWeek4MobileDev.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Repositories
{
    public class UserRepository
    {

        SQLiteConnection connection;
        public string? statusMessage { get; set; }

        public UserRepository()
        {
            connection = new SQLiteConnection(
               Constants.DatabasePath,
               Constants.flags);

            connection.CreateTable<User>();

        }

        public void AddOrUpdate(User member)
        {
            int result = 0;        
            if (member.Id == 0)
            {
                member.Discriminator = "Member";
                result = connection.Insert(member);
                statusMessage = string.Format("{0} record(s) added [Name: {1})", result, member.Name);
            }
            else
            {
                result = connection.Update(member);
                statusMessage = string.Format("{0} record(s) updated [Name: {1})", result, member.Name);
            }
        }


        public bool LoginUser(string username, string password)
        {
            var loggedInUser = connection.Table<User>()
                .Where(u => u.Name == username && u.Password == password);

            if(loggedInUser == null)
            {
                return false;
            }

            return true;
        }


    }
}
