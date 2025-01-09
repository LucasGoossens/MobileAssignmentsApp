using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Models;
using InleverenWeek4MobileDev.Repositories;
using InleverenWeek4MobileDev.Session;
using System.Collections.ObjectModel;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class CommentsViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(CommentsCountText))]
        private ObservableCollection<Comment> subMissionComments;

        public int SubmissionId { get; set; }

        [ObservableProperty]
        private string commentSubmit;

        public bool SubmitEnabled => !string.IsNullOrWhiteSpace(CommentSubmit);


        public string CommentsCountText => SubMissionComments.Count == 1 ? "1 Comment" : $"{SubMissionComments?.Count ?? 0} Comments";

        public CommentsViewModel(int submissionId)
        {
            SubmissionId = submissionId;
            SubMissionComments = new ObservableCollection<Comment>();
            LoadComments();
        }

        public async void LoadComments()
        {
            CommentRepository commentRepository = new CommentRepository();
            var loadedComments = await Task.Run(() => commentRepository.GetAllCommentsBySubmissionId(SubmissionId));
            SubMissionComments = new ObservableCollection<Comment>(loadedComments);
            //for (int i = 0; i < 20; i++)
            //{

            //    SubMissionComments.Add(new Comment
            //    {
            //        User = new User { Name = "TestUser1", ProfilePicture = "ocean.jpg" },
            //        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas imperdiet vel orci in condimentum. Vivamus auctor turpis quam, vitae pulvinar velit aliquam quis. Maecenas sed vestibulum tellus, non tincidunt sem. ",
            //        Likes = 25,
            //        Replies = new List<Comment>()
            //    });
            //}
        }

        [RelayCommand(CanExecute = nameof(SubmitEnabled))]
        public void SendComment()
        {
            Comment comment = new Comment
            {
                UserId = UserSession.Instance.UserId,
                User = UserSession.Instance.LoggedInUser,
                SubmissionId = SubmissionId,
                Content = CommentSubmit,
                Likes = 0
            };

            CommentRepository commentRepository = new CommentRepository();
            commentRepository.AddComment(comment);            

            CommentSubmit = "";

            LoadComments();
        }

        [RelayCommand]
        public async Task NavigateToProfile(int userId)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Profile(userId));
        }
    }
}
