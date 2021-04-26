using ImageProcessor;
using System;
using System.IO;

namespace FlowHelpers.Models
{
    public class Saturation : BaseImage
    {
        public int depth { get; set; }
        public static string ProcessImage(Saturation req)
        {
            string file = req.content;
            byte[] photoBytes = Convert.FromBase64String(file);

            var depth = req.depth;
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .Saturation(depth)
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