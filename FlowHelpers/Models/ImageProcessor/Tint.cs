using ImageProcessor;
using System;
using System.Drawing;
using System.IO;

namespace FlowHelpers.Models
{
    public class Tint : BaseImage
    {
        public Color tintcolor { get; set; }
        public static string ProcessImage(Tint req)
        {
            string file = req.content;
            byte[] photoBytes = Convert.FromBase64String(file);

            Color color = req.tintcolor;

            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .Tint(color)
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