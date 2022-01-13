using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NewsApi.Context;
using NewsApi.Enum;
using NewsApi.Models;
using NewsApi.Models.MedeeModels;
using NewsApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace NewsApi.Logics
{
    public class CatalogLogic
    {
        public static string GetUniqueFileName(string extension)
        {
            return $"{Guid.NewGuid()}.{extension.Replace(".", "")}";
        }
        public static async Task<string> CopyToFile(IFormFile file)
        {
            try
            {
                if (Path.GetExtension(file.FileName) == ".doc" || Path.GetExtension(file.FileName) == ".xls")
                {
                    string extension = Path.GetExtension(file.FileName).ToLower();
                    var fileName = GetUniqueFileName(extension);
                    var path = Path.Combine("Resource", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                        await file.CopyToAsync(fileStream);
                    return fileName;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        
    }
}
