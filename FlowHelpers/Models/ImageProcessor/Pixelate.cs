using ImageProcessor;
using System;
using System.IO;

namespace FlowHelpers.Models
{
    public class Pixelate : BaseImage
    {
        public int pixels { get; set; }

        public static string ProcessImage(Pixelate req)
        {
            string file = req.content;
            byte[] photoBytes = Convert.FromBase64String(file);
            int pixels = req.pixels;

            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    // Initialize the ImageFactory using the overload to preserve EXIF metadata.
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        // Load, resize, set the format and quality and save an image.
                        imageFactory.Load(inStream)
                                    .Pixelate(pixels)
                                    .Save(outStream);
                    }
                    // Do something with the stream.
                    var bytes = outStream.ToArray();
                    var base64Image = Convert.ToBase64String(bytes);
                    return base64Image;
                }
            }
        }
    }
}