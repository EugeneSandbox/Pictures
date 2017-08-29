using System;
using System.IO;
using System.IO.Compression;



namespace Pictures.Tools
{
    public static class Helper
    {
        /// <summary>
        /// Compress string
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Compress(string data)
        {
            var byteArray = ConvertToByteArray(data);
            var compressedByteArray = Compress(byteArray);
            return ConvertToBase64String(compressedByteArray);
        }
        /// <summary>
        /// Compress byte array
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Compress(byte[] data)
        {
            using (var compressedStream = new MemoryStream())
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
            {
                zipStream.Write(data, 0, data.Length);
                zipStream.Close();
                return compressedStream.ToArray();
            }
        }


        /// <summary>
        /// Decompress string
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Decompress(string data)
        {
            var compressedByteArray = ConvertToByteArray(data);
            var byteArray = Decompress(compressedByteArray);
            return ConvertToBase64String(byteArray);
        }
        /// <summary>
        /// Decompress byte array
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] data)
        {
            using (var compressedStream = new MemoryStream(data))
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            using (var resultStream = new MemoryStream())
            {
                var buffer = new byte[4096];
                int read;

                while ((read = zipStream.Read(buffer, 0, buffer.Length)) > 0)
                    resultStream.Write(buffer, 0, read);

                return resultStream.ToArray();
            }
        }


        /// <summary>
        /// Convert byte array to base64 string
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ConvertToBase64String(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return Convert.ToBase64String(data);
        }
        
        /// <summary>
        /// Convert string to byte array
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] ConvertToByteArray(string data)
        {
            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException(nameof(data));

            return Convert.FromBase64String(data);
        }
    }
}
