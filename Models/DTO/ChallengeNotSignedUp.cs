using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Models.DTO
{
    public class ChallengeNotSignedUpDTO
    {       

        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageSource { get; set; }
        public string Description { get; set; }
        public ChallengeNotSignedUpDTO(int id, string title, string imageSource, string description)
        {
            Id = id;
            Title = title;
            ImageSource = imageSource;
            Description = description;
        }
    }
}
