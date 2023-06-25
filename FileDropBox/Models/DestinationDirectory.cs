namespace FileDropBox.Models
{
    public class DestinationDirectory
    {
        public string DestPath { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public bool Exists { get; set; }
    }
}