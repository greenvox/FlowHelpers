using ImageProcessor;
using ImageProcessor.Imaging;
using System;
using System.IO;

namespace FlowHelpers.Models
{
    public class Watermark : BaseImage
    {
        public TextLayer watermark { get; set; }
        public static string ProcessImage(Watermark req)
        {
            string file = req.content;
            byte[] photoBytes = Convert.FromBase64String(file);

            var watermarkLayer = req.watermark;
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .Watermark(watermarkLayer)
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