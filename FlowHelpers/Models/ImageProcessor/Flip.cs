using ImageProcessor;
using System;
using System.IO;

namespace FlowHelpers.Models
{
    public class Flip : BaseImage
    {
        public bool flipvertically { get; set; }
        public static string ProcessImage(Flip req)
        {
            string file = req.content;
            byte[] photoBytes = Convert.FromBase64String(file);

            var flipVertically = req.flipvertically;
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .Flip(flipVertically)
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