namespace FileSystemAssessmentProject.Logging
{
    internal class LogReader
    {
        public async Task<string> ReadLogAsync(string fileName)
        {
            string filePath = $"Logs//{fileName}";

            if (File.Exists(filePath))
            {
                return await File.ReadAllTextAsync(filePath);
            }
            else
            {
                throw new FileNotFoundException($"The file {fileName} does not exist.");
            }
        }
    }
}
