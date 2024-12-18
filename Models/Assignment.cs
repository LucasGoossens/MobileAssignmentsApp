﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public Dictionary<string, string> Guides { get; set; }
        [Column("GuidesJson")]
        public string GuidesJson
        {
            get => Guides != null ? JsonSerializer.Serialize(Guides) : null;
            set => Guides = !string.IsNullOrEmpty(value) ? JsonSerializer.Deserialize<Dictionary<string, string>>(value) : null;
        }

        [Ignore]
        public List<Submission> Submissions { get; set; }

        [Ignore]
        public string Status { get; set; }
        // dit gaat over of assignment Locked, Unlocked of Completed is

        public void UnlockAssignment(int userId)
        {

        }

        public void SetHeaderImage()
        {
            // hier dan de image van de meest populaire submission als header?
        }
    }
}
