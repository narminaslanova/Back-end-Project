using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Extensions
{
    public static class Extension
    {
        public static bool IsValidType(this IFormFile file, string type)
        {

            return file.ContentType.Contains(type);
        }
        public static bool IsValidSize(this IFormFile file, int kb)
        {
            return file.Length / 1024 <= kb;
        }
        public static async Task<string> SaveFileAsync(this IFormFile file, string root, string folder)
        {
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string rooting = Path.Combine(root, folder);
            string resultPath = Path.Combine(rooting, fileName);


            using (FileStream fileStream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }
    }
}
