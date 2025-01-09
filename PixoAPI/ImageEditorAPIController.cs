using System.Text;
using System.Text.Json;

namespace InleverenWeek4MobileDev.PixoAPI
{
    public class ImagePayload
    {
        public string Apikey { get; set; }
        public string Src { get; set; }
    }

    public class ImagePayloadFilter : ImagePayload
    {
        public string Filter { get; set; }
    }

    public class ImagePayloadAdjust : ImagePayload
    {
        public Dictionary<string, double> Adjust { get; set; }
    }

    public class ImageEditorAPIController
    {
        private readonly string apiUrl = "https://pixoeditor.com/api/image/";
        private readonly string apiKey = "2yphzv7naee0";
        private static readonly HttpClient httpClient = new HttpClient();
        public ImagePayload ImagePayload { get; set; }
        public string ImageFilePath { get; set; }

        public async Task ApplyFilter(string filePath, string filter)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new ArgumentException("File path cannot be empty", nameof(filePath));
                }

                if (string.IsNullOrEmpty(filter))
                {
                    throw new ArgumentException("Filter cannot be empty", nameof(filter));
                }

                ImagePayload = new ImagePayloadFilter
                {
                    Apikey = apiKey,
                    Filter = filter
                };

                await FormatLocalFileAsync(filePath);
                await ExecuteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ApplyFilter: {ex.Message}");
                throw; // Rethrow to handle in the ViewModel
            }
        }

        public async Task ApplyColorAdjustment(string filePath, Dictionary<string, double> adjust)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new ArgumentException("File path cannot be empty", nameof(filePath));
                }

                if (adjust == null || !adjust.Any())
                {
                    throw new ArgumentException("Adjustments cannot be empty", nameof(adjust));
                }

                ImagePayload = new ImagePayloadAdjust
                {
                    Apikey = apiKey,
                    Adjust = adjust
                };

                await FormatLocalFileAsync(filePath);
                await ExecuteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ApplyColorAdjustment: {ex.Message}");
                throw;
            }
        }

        private async Task ExecuteAsync()
        {
            try
            {
                string jsonContent = SerializePayload();
                //Console.WriteLine($"Request Payload: {jsonContent}");

                HttpResponseMessage response = await SendRequest(jsonContent);
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response Status: {response.StatusCode}");
                //Console.WriteLine($"Response Content: {responseContent}");

                if (response.IsSuccessStatusCode)
                {
                    byte[] fileBytes = await response.Content.ReadAsByteArrayAsync();
                    string outputFilePath = await SaveFileAsync(fileBytes);
                    ImageFilePath = outputFilePath;

                    Console.WriteLine($"File saved successfully: {outputFilePath}");
                }
                else
                {
                    throw new HttpRequestException($"API Request failed: {responseContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ExecuteAsync: {ex.Message}");
                throw;
            }
        }

        private async Task FormatLocalFileAsync(string localImagePath)
        {
            try
            {
                using var fileStream = new FileStream(localImagePath, FileMode.Open, FileAccess.Read);
                using var memoryStream = new MemoryStream();
                await fileStream.CopyToAsync(memoryStream);
                ImagePayload.Src = Convert.ToBase64String(memoryStream.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in FormatLocalFile: {ex.Message}");
                throw;
            }
        }

        private string SerializePayload()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                return JsonSerializer.Serialize(ImagePayload, ImagePayload.GetType(), options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error serializing payload: {ex.Message}");
                throw;
            }
        }

        private async Task<HttpResponseMessage> SendRequest(string jsonContent)
        {
            try
            {
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                Console.WriteLine($"Sending request to: {apiUrl}");
                Console.WriteLine($"Request content: {await content.ReadAsStringAsync()}");
                return await httpClient.PostAsync(apiUrl, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending request: {ex.Message}");
                Console.WriteLine($"Error sending request: {ex.StackTrace}");
                throw;
            }
        }

        private async Task<string> SaveFileAsync(byte[] fileBytes)
        {
            try
            {
                string fileName = $"{DateTime.Now.Ticks}.jpeg";
                string filePath = GetOutputFilePath(fileName);
                await File.WriteAllBytesAsync(filePath, fileBytes);
                return filePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
                throw;
            }
        }

        private string GetOutputFilePath(string fileName)
        {
            try
            {
#if ANDROID || IOS
                return Path.Combine(FileSystem.AppDataDirectory, fileName);
#elif WINDOWS
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
#else
                throw new PlatformNotSupportedException("Platform not supported");
#endif
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting output path: {ex.Message}");
                throw;
            }
        }
    }
}