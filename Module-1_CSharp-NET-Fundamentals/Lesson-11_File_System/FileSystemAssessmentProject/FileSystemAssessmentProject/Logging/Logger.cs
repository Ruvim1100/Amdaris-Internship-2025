using FileSystemAssessmentProject.Constants;
using FileSystemAssessmentProject.Entities;
using FileSystemAssessmentProject.Services;

namespace FileSystemAssessmentProject.Logging
{
    internal class Logger<T>
    {
        private const string path = "Logs";

        public async Task LogInfoAsync(string message)
        {
            
            await WriteLog(string.Format(LogConstants.logFormat, DateTime.Now, "Info", typeof(T), true, message));
        }

        public async Task LogWarningAsync(string message)
        {
            await WriteLog(string.Format(LogConstants.logFormat, DateTime.Now, "Warning", typeof(T), true, message));
        }

        public async Task LogErrorAsync(string message)
        {
            await WriteLog(string.Format(LogConstants.logFormat, DateTime.Now, "Error", typeof(T), false, message));
        }

        private async Task WriteLog(string message)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = $"{DateTime.Now.ToString("yyyy-MM-dd")}.txt";
            string filePath = $"{path}\\{fileName}";

            await File.AppendAllTextAsync(filePath, message +Environment.NewLine);
        }

    }
}
