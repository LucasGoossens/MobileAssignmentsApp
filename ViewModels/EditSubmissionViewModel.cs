using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InleverenWeek4MobileDev.PixoAPI;
using InleverenWeek4MobileDev.Repositories;
using InleverenWeek4MobileDev.Views;

namespace InleverenWeek4MobileDev.ViewModels
{
    public partial class EditSubmissionViewModel : ObservableObject
    {
        public List<string> Filters { get; set; }
        public Models.Submission Submission { get; set; }

        [ObservableProperty]
        private string currentImage;

        [ObservableProperty]
        private bool isLoading;
        public List<string> EditHistory { get; set; }

        public EditSubmissionViewModel(Models.Submission submission)
        {
            Filters = new List<string> { "Sepia", "Autumn", "Nightfall", "BlackWhite", "Vintage", "Technicolor", "Polaroid", "Invert", "Distressed" };
            Submission = submission;
            CurrentImage = File.Exists(submission.Image) ? submission.Image : string.Empty;

            EditHistory = new List<string>();
            EditHistory.Add(File.Exists(submission.Image) ? submission.Image : string.Empty);

            Console.WriteLine("Initialized EditSubmissionViewModel");
            Console.WriteLine($"CurrentImage: {CurrentImage}");
        }

        public EditSubmissionViewModel() { }

        [RelayCommand]
        public async Task Filter()
        {
            var selectedFilter = await Application.Current.MainPage.DisplayActionSheet(
                "Select Filter",
                "Cancel",
                null,
                Filters.ToArray());

            if (selectedFilter != "Cancel" && Filters.Contains(selectedFilter))
            {
                System.Diagnostics.Debug.WriteLine($"Selected filter: {selectedFilter}");
                await ApplyFilter(selectedFilter);
            }
        }

        public async Task ApplyFilter(string filter)
        {
            try
            {
                IsLoading = true;
                var imageEditorAPIController = new ImageEditorAPIController();
                await imageEditorAPIController.ApplyFilter(CurrentImage, filter);

                if (!string.IsNullOrEmpty(imageEditorAPIController.ImageFilePath) &&
                    File.Exists(imageEditorAPIController.ImageFilePath))
                {
                    var newImagePath = imageEditorAPIController.ImageFilePath;

                    await MainThread.InvokeOnMainThreadAsync(() =>
                    {
                        CurrentImage = newImagePath;
                        EditHistory.Add(newImagePath);
                    });

                    await Task.Run(() =>
                    {                        
                        Submission.Image = newImagePath;                        
                    });

                    Console.WriteLine($"Updated CurrentImage: {CurrentImage}");
                }
                else
                {
                    Console.WriteLine("File path is invalid or file does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error applying filter: {ex.Message}");
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Error", $"Failed to apply filter: {filter}. {ex.Message}", "OK");
                });
            }
            finally
            {
                IsLoading = false;
            }
        }



        // Red Slider (Range: 0.01 to 2.2)
        [ObservableProperty]
        private double redValue;

        // Green Slider (Range: 0.01 to 2.2)
        [ObservableProperty]
        private double greenValue;

        // Blue Slider (Range: 0.01 to 2.2)
        [ObservableProperty]
        private double blueValue;

        // Saturation Slider (Range: -1 to 1)
        [ObservableProperty]
        private double saturationValue;

        // Brightness Slider (Range: -1 to 1)
        [ObservableProperty]
        private double brightnessValue;

        // Contrast Slider (Range: -1 to 1)
        [ObservableProperty]
        private double contrastValue;

        // Blur Slider (Range: 0 to 1)
        [ObservableProperty]
        private double blurValue;

        // Noise Slider (Range: 0 to 1000)
        [ObservableProperty]
        private double noiseValue;

        //  Pixelate Slide (range 2 to 20)
        [ObservableProperty]
        private double pixelateValue;

        [RelayCommand]
        public async Task ShowColorPicker()
        {
            var colorPickerPopup = new ColorPickerPopup
            {
                BindingContext = this
            };
            await Application.Current.MainPage.Navigation.PushModalAsync(colorPickerPopup);
        }

        [RelayCommand]
        public async Task ApplyColor()
        {
            var adjust = new Dictionary<string, double>();

            if (RedValue != 0) adjust.Add("gamma-red", RedValue);
            if (GreenValue != 0) adjust.Add("gamma-green", GreenValue);
            if (BlueValue != 0) adjust.Add("gamma-blue", BlueValue);
            if (SaturationValue != 0) adjust.Add("saturation", SaturationValue);
            if (BrightnessValue != 0) adjust.Add("brightness", BrightnessValue);
            if (ContrastValue != 0) adjust.Add("contrast", ContrastValue);
            if (BlurValue != 0) adjust.Add("blur", BlurValue);
            if (NoiseValue != 0) adjust.Add("noise", NoiseValue);
            if (PixelateValue != 0) adjust.Add("pixelate", PixelateValue);

            if (adjust.Count > 0)
            {

                ImageEditorAPIController imageEditorAPIController = new ImageEditorAPIController();
                await imageEditorAPIController.ApplyColorAdjustment(CurrentImage, adjust);

                if (!string.IsNullOrEmpty(imageEditorAPIController.ImageFilePath))
                {
                    CurrentImage = imageEditorAPIController.ImageFilePath;
                    EditHistory.Add(imageEditorAPIController.ImageFilePath);

                    if (File.Exists(CurrentImage))
                    {
                        Console.WriteLine("File exists and is ready to use.");
                        ClosePopup();
                        ResetValues();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist at the specified path.");
                    }
                }
                else
                {
                    Console.WriteLine("ImageFilePath is null or empty. Update failed.");
                }
            }
        }

        [RelayCommand]
        public void UndoChanges()
        {
            if (EditHistory.Count <= 1) return;

            EditHistory.RemoveAt(EditHistory.Count - 1);
            CurrentImage = EditHistory[EditHistory.Count - 1];
        }

        [RelayCommand]
        public async void SaveChanges()
        {
            var submissionRepository = new SubmissionRepository();
            submissionRepository.UpdateSubmission(Submission);
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public void ResetValues()
        {
            RedValue = 0;
            GreenValue = 0;
            BlueValue = 0;
            SaturationValue = 0;
            BrightnessValue = 0;
            ContrastValue = 0;
            BlurValue = 0;
            NoiseValue = 0;
            PixelateValue = 0;

            Console.WriteLine("All values have been reset to 0");
        }

        // Command to close the popup
        [RelayCommand]
        public void ClosePopup()
        {
            Application.Current.MainPage.Navigation.PopModalAsync();
        }

    }
}
