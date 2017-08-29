using System;
using System.IO;



namespace Pictures.FilesLoader
{
    using PictureService;
    using Tools;


    class Program
    {
        private const string sourceDirectory = @"d:\temp\wallpapers\";
        private static Service pictureService = new Service();


        static void Main(string[] args)
        {
            var files = Directory.GetFiles(sourceDirectory, "*.jpg");
            foreach (var file in files)
                LoadFileToDatabase(file);
        }


        /// <summary>
        /// Load file to database
        /// </summary>
        /// <param name="filePath">Path to file</param>
        private static void LoadFileToDatabase(string filePath)
        {
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var imageBytes = new byte[fileStream.Length];
            fileStream.Read(imageBytes, 0, imageBytes.Length);

            var imageBase64String = Helper.ConvertToBase64String(imageBytes);

            var newPicture = new Picture()
            {
                Title = filePath.Substring(filePath.LastIndexOf(@"\") + 1),
                Image = imageBase64String
            };
            Console.WriteLine(@"Loading... " + filePath);
            pictureService.Add(newPicture);
        }
    }
}      