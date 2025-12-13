using System;
using System.Collections.Generic;

namespace FileExtensionAssistant
{
    class FileExtensionInfo
    {
        private Dictionary<string, string> extensions;

        public FileExtensionInfo()
        {
            extensions = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { ".mp4", "MPEG-4 Video File" },
                { ".mov", "Apple QuickTime Movie" },
                { ".avi", "Audio Video Interleave File" },
                { ".mkv", "Matroska Video File" },
                { ".webm", "WebM Video File" },
                { ".jpg", "JPEG Image" },
                { ".png", "Portable Network Graphics" },
                { ".gif", "Graphics Interchange Format" },
                { ".bmp", "Bitmap Image File" },
                { ".txt", "Plain Text File" },
                { ".doc", "Microsoft Word Document" },
                { ".docx", "Microsoft Word Open XML Document" },
                { ".pdf", "Portable Document Format" },
                { ".xls", "Microsoft Excel Spreadsheet" },
                { ".xlsx", "Microsoft Excel Open XML Spreadsheet" },
                { ".ppt", "Microsoft PowerPoint Presentation" },
                { ".pptx", "Microsoft PowerPoint Open XML Presentation" },
                { ".mp3", "MP3 Audio File" },
                { ".wav", "Waveform Audio File" },
                { ".flac", "Free Lossless Audio Codec File" },
                { ".epub", "Electronic Publication format" }
            };
        }

        public void GetInfo(string ext)
        {
            if (!ext.StartsWith("."))
                ext = "." + ext;

            if (extensions.TryGetValue(ext, out string description))
                Console.WriteLine($"{ext} : {description}");
            else
                Console.WriteLine($"Sorry, '{ext}' is not recognized in our database.");
        }
    }
}
