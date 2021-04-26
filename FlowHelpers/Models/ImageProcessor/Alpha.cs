using System;
using System.IO;
using ImageProcessor;

namespace FlowHelpers.Models
{
    public class Alpha : BaseImage
    {
        public int percentage { get; set; }
        public static string ProcessImage(Alpha req)
        {

            string file = req.content;
            byte[] photoBytes = Convert.FromBase64String(file);

            int percentage = req.percentage;

            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .Alpha(percentage)
                                    .Save(outStream);
                    }
                    var bytes = outStream.ToArray();
                    var base64Image = Convert.ToBase64String(bytes);

                    return base64Image;
                }
            }
        }
    }
}