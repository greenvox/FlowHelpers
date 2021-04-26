using ImageProcessor;
using System;
using System.IO;

namespace FlowHelpers.Models
{
    public class GaussianSharpen : BaseImage
    {
        public int sharpen { get; set; }
        public static string ProcessImage(GaussianSharpen req)
        {
            string file = req.content;
            byte[] photoBytes = Convert.FromBase64String(file);

            var sharpen = req.sharpen;
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .GaussianSharpen(sharpen)
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