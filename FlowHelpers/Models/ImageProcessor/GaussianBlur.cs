using ImageProcessor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FlowHelpers.Models
{
    public class GaussianBlur : BaseImage
    {
        public int blur { get; set; }
        public static string ProcessImage(GaussianBlur req)
        {
            string file = req.content;
            byte[] photoBytes = Convert.FromBase64String(file);

            var sharpen = req.blur;
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