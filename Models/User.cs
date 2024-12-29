using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Models
{
    [Table("Users")]   
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Discriminator { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }        
        public string Password { get; set; }
        public int Credits { get; set; }
        public string ProfilePicture { get; set; }
    }
}
