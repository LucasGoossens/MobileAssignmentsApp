using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class CreateChallengeViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;

        [RelayCommand]
        public void SubmitChallenge()
        {
            ChallengeRepository challengeRepository = new ChallengeRepository();
            Challenge challenge = new Challenge();
            challenge.Title = title;
            challenge.Description = description;
            challengeRepository.AddOrUpdate(challenge);

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SQLiteInleverenWeek7.db3");
            Console.WriteLine($"Database Path: {dbPath}");

        }
    }
}
