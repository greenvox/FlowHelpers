using ImageProcessor;
using System;
using System.Drawing;
using System.IO;

namespace FlowHelpers.Models
{
    public class Resize: BaseImage
    {
        public Size dimensions { get; set; }

        public static string ProcessImage(Resize req)
        {
            string file = req.content;
            byte[] photoBytes = Convert.FromBase64String(file);

            Size size = req.dimensions;
            
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .Resize(size)
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