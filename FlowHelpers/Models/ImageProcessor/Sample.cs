using ImageProcessor;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FlowHelpers.Models
{
    public class Sample : BaseImage
    {
        public string name { get; set; }
        public string mimetype { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int pixels { get; set; }

        public static HttpResponseMessage ProcessImage(Sample req)
        {
            string file = req.content;
            byte[] photoBytes = Convert.FromBase64String(file);

            Size size = new Size(req.width, req.height);
            int pixels = req.pixels;

            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .Resize(size)
                                    .Pixelate(pixels)
                                    .Save(outStream);
                    }
                    var bytes = outStream.ToArray();
                    var base64Image = Convert.ToBase64String(bytes);

                    var response = new HttpResponseMessage();
                    response.Content = new StringContent("<img src='data:image/jpeg;base64," + base64Image + "'>");
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
                    return response;
                }
            }
        }
    }
}