using ImageMagick;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace WebApplication1.Handlers
{
    public class ExampleHandlers
    {
        //Route Hnadler
        public RequestDelegate Handler(string filePath)
        {
            return async c =>
            {
                FileInfo fileInfo = new FileInfo($"{filePath}\\{c.Request.RouteValues["imageName"].ToString()}");
                using MagickImage magick = new(fileInfo);

                int widht = magick.Width , height = magick.Height;

                if (!string.IsNullOrEmpty(c.Request.Query["w"].ToString()))
                {
                    widht = int.Parse(c.Request.Query["w"].ToString());
                }
                if (!string.IsNullOrEmpty(c.Request.Query["h"].ToString()))
                {
                    widht = int.Parse(c.Request.Query["h"].ToString());
                }

                magick.Resize(widht, height);

                var buffer = magick.ToByteArray();
                c.Response.Clear();
                c.Response.ContentType = string.Concat("image/", fileInfo.Extension.Replace(".",""));

                await c.Response.Body.WriteAsync(buffer, 0, buffer.Length);
                await c.Response.WriteAsync(filePath);
            };
        }
    }
}
