using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System;
using System.IO;

namespace FlowHelpers.Models
{
    public class Format : BaseImage
    {
        public ISupportedImageFormat imageformat { get; set; }

        public static string ProcessImage(Format req)
        {
            string file = req.content;
            byte[] photoBytes = Convert.FromBase64String(file);

            var format = req.imageformat;
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .Format(format)
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