﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Models
{
    public class Member : User
    {
        [Ignore]
        public List<Comment> Comments { get; set; }
    }
}