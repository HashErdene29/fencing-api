using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NewsApi.Context;
using NewsApi.Enum;
using NewsApi.Models.AuthModels;
using NewsApi.Models.FilterModels;
using NewsApi.Models.UserModels;
using NewsApi.Models;
using NewsApi.Models.CategoryModels;
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
        public static async Task<ResponseClient> AddCategory(PostgregDbContext _dbContext, IFormFile file, IFormFile image, AddCategoryModel model)
        {
            try
            {
                var fileurl = UsefulHelpers.CopyToFile(file).Result;
                var imgurl = UsefulHelpers.UploadImage(_dbContext, image, 1);

                if (_dbContext.CATEGORYs.FirstOrDefault(x => x.NAME.Equals(model.name)) != null)
                    return ReturnResponse.InvalidResult("Ийм нэртэй үйлчилгээ бүртгэгдсэн байна.");

                decimal categoryid = UsefulHelpers.GetTableID(_dbContext, "CATEGORY");
                _dbContext.CATEGORYs.Add(new CATEGORY
                {
                    ID = categoryid,
                    NAME = model.name,
                    IMAGE = imgurl,
                    CONTRACTID = model.contractid,
                    CONTRACTFILE = fileurl,
                    INSYMD = DateTime.Now,
                });
                _dbContext.SaveChanges();
                return ReturnResponse.ObjectResult(null);
            }
            catch (Exception ex)
            {
                return ReturnResponse.InvalidResult(ex.Message, "Мэдээлэл хадгалах үед алдаа гарлаа!");
            }
        }

        public static async Task<ResponseClient> UserVerify(PostgregDbContext _dbContext, IFormFile file, List<IFormFile> image, UserVerify model)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return null;
                var user = _dbContext.USERs.FirstOrDefault(x => x.ID == model.userid);
                var fileurl = UsefulHelpers.CopyToFile(file).Result;
                foreach(var i in image)
                {
                    decimal jobimgid = UsefulHelpers.GetTableID(_dbContext, "JOBIMG");
                    var imgurl = UsefulHelpers.UploadImage(_dbContext, i, 1);
                    _dbContext.JOBIMGs.Add(new JOBIMG
                    {
                        ID = jobimgid,
                        CATID = model.catid,
                        IMG = imgurl
                    });
                }
                decimal jobid = UsefulHelpers.GetTableID(_dbContext, "JOB");
                _dbContext.JOBs.Add(new JOB
                {
                    ID = jobid,
                    CATID = model.catid,
                    USERID = model.userid,
                    PRICE = model.price,
                    TYPE = model.type,
                    INSYMD = DateTime.Now,
                    CVALUE = fileurl,
                });
                _dbContext.SaveChanges();
                return ReturnResponse.ObjectResult(null);
            }
            catch (Exception ex)
            {
                return ReturnResponse.InvalidResult(ex.Message, "Мэдээлэл хадгалах үед алдаа гарлаа!");
            }
        }

        public static async Task<ResponseClient> AddBanner(PostgregDbContext _dbContext, List<IFormFile> image, AddBannerModel model)
        {
            try
            {
                foreach (var i in image)
                {
                    decimal bannerid = UsefulHelpers.GetTableID(_dbContext, "BANNER");
                    var imgurl = UsefulHelpers.UploadImage(_dbContext, i, 1);
                    _dbContext.JOBIMGs.Add(new JOBIMG
                    {
                        ID = bannerid,
                        IMG = imgurl
                    });
                }
                _dbContext.SaveChanges();
                return ReturnResponse.ObjectResult(null);
            }
            catch (Exception ex)
            {
                return ReturnResponse.InvalidResult(ex.Message, "Мэдээлэл хадгалах үед алдаа гарлаа!");
            }
        }
        public static async Task<ResponseClient> CreateOrder(PostgregDbContext _dbContext, IFormFile image, CreateOrderModel model)
        {
            try
            {
                decimal orderid = UsefulHelpers.GetTableID(_dbContext, "ORDER");
                var imgurl = UsefulHelpers.UploadImage(_dbContext, image, 1);
                _dbContext.ORDERs.Add(new ORDER
                {
                    ID = orderid,
                    IMG = imgurl,
                    USERID = model.userid,
                    CATID = model.catid,
                    JOBID = model.jobid,
                    DATE= model.date,
                    STATUS = Status.Захиалга_үүссэн,
                    INSYMD = DateTime.Now,
                    DESCRIPTION = model.description
                });

                _dbContext.SaveChanges();
                return ReturnResponse.ObjectResult(null);
            }
            catch (Exception ex)
            {
                return ReturnResponse.InvalidResult(ex.Message, "Мэдээлэл хадгалах үед алдаа гарлаа!");
            }
        }
    }
}
