using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.Models.DTO
{
    public partial class UserAverage : ObservableObject
    {
        [ObservableProperty]
        public int count;
        [ObservableProperty]
        public double average;
        public UserAverage()
        {
        
        }
    }
}
