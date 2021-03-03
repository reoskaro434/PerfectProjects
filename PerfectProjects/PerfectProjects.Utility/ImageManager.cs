using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PerfectProjects.Utility
{
    public class ImageManager
    {
        static public byte[] ConvertToByteArray(IFormFile Image)
        {
            Stream stream = Image.OpenReadStream();
            MemoryStream memStream = new MemoryStream();
            stream.CopyTo(memStream);

           return memStream.ToArray();
        }

        static public string ConvertToString(byte[] ByteArray)
        {
            return Convert.ToBase64String(ByteArray);
        }
    }
}
