using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NewsApi.Context;
using NewsApi.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NewsApi.Logics;
using System.IO;

namespace NewsApi.Utils
{
    public class UsefulHelpers
    {
        public static int GetTableID(PostgregDbContext _dbContext, string tableName)
        {
            try
            {
                int id;
                var connection = _dbContext.Database.GetDbConnection();
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT nextval('" + tableName + "_seq');";
                    var obj = cmd.ExecuteScalar();
                    id = (int)(long)obj;
                }
                connection.Close();
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string HashPass(string password)
        {
            try
            {
                var sha256 = SHA256.Create();
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public static string GetUniqueFileName(string extension)
        {
            return $"{Guid.NewGuid()}.{extension.Replace(".", "")}";
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public static string UploadImage(PostgregDbContext _dbContext, IFormFile image, decimal type)
        {
            try
            {
                if (image == null || image.Length == 0)
                    return null;

                var folder = "Resource";

                string extension = Path.GetExtension(image.FileName).ToLower();
                var file = Image.FromStream(image.OpenReadStream(), true, true);
                var fileName = GetUniqueFileName(extension);
                var path = Path.Combine(folder, fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    if (type == 1)
                        file = UsefulHelpers.ScaleImage(file, 100);
                    file.Save(fileStream, ImageFormat.Jpeg);
                }
                return path;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> CopyToFile(IFormFile file)
        {
            try
            {
                if (Path.GetExtension(file.FileName) == ".xlsx" || Path.GetExtension(file.FileName) == ".xls")
                {
                    string extension = Path.GetExtension(file.FileName).ToLower();
                    var fileName = GetUniqueFileName(extension);
                    var path = Path.Combine("Resource", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                        await file.CopyToAsync(fileStream);
                    return path;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static Image ScaleImage(Image image, int height)
        {
            double ratio = (double)height / image.Height;
            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);
            var destRect = new Rectangle(0, 0, newWidth, newHeight);
            var destImage = new Bitmap(newWidth, newHeight);
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }
    }
}
