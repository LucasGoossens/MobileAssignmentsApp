using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.Session;
using InleverenWeek4MobileDev.Repositories;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class PhotoPickerModalViewModel : ObservableObject
    {
        public int AssignmentId { get; set; }

        public PhotoPickerModalViewModel(int assignmentId)
        {
            AssignmentId = assignmentId;
        }
        [RelayCommand]
        public async Task PickFromDeviceAsync()
        {
            // Pick a photo from the device
            FileResult file = await MediaPicker.PickPhotoAsync();

            if (file != null)
            {
                // Handle the file (save or process)
                await HandleFile(file);
            }

            await CloseModalAsync();
        }

        [RelayCommand]
        public async Task TakePictureAsync()
        {
            // Capture a photo using the device's camera
            FileResult file = await MediaPicker.CapturePhotoAsync();

            if (file != null)
            {
                // Handle the captured photo
                await HandleFile(file);
            }

            await CloseModalAsync();
        }

        public async Task HandleFile(FileResult file)
        {
            // Ensure file is valid
            if (file == null)
                return;

            string filePath = Path.Combine(FileSystem.CacheDirectory, file.FileName);

            using Stream sourceStream = await file.OpenReadAsync();
            
            using FileStream localFileStream = File.OpenWrite(filePath);

            await sourceStream.CopyToAsync(localFileStream);

            Models.Submission submission = new Models.Submission();            
            submission.AssignmentId = AssignmentId;
            submission.CreatorId = UserSession.Instance.UserId;
            submission.Image = filePath;
            submission.Likes = 0;

            SubmissionRepository submissionRepository = new SubmissionRepository();
            submissionRepository.AddSubmission(submission);

            MemberAssignmentRepository memberAssignmentRepository = new MemberAssignmentRepository();
            memberAssignmentRepository.SetAssignmentStatus(UserSession.Instance.UserId, AssignmentId, "Completed");
        }



        [RelayCommand]
        public async Task CancelAsync()
        {
            await CloseModalAsync();
        }

        private async Task CloseModalAsync()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
