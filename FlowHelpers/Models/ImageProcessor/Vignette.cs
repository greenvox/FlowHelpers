using ImageProcessor;
using System;
using System.Drawing;
using System.IO;

namespace FlowHelpers.Models
{
    public class Vignette : BaseImage
    {
        public Color vignettecolor { get; set; }
        public static string ProcessImage(Vignette req)
        {
            string file = req.content;
            byte[] photoBytes = Convert.FromBase64String(file);

            Color color = req.vignettecolor;

            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .Vignette(color)
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