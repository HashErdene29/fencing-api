using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsApi.Context;
using NewsApi.Enum;
using NewsApi.Logics;
using NewsApi.Models.AuthModels;
using NewsApi.Models.CategoryModels;
using NewsApi.Models.FilterModels;
using NewsApi.Models.UserModels;
using NewsApi.Models;
using NewsApi.Utils;
using Newtonsoft.Json;
using NewsApi.Utils;

namespace NewsApi.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api")]
    public class WebController : Controller
    {
        #region Fields
        readonly ILogger<WebController> _logger;
        private readonly PostgregDbContext _dbContext;
        #endregion

        #region Initialize
        public WebController(PostgregDbContext dbContext, ILogger<WebController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Login 
        /// </summary>
        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ResponseClient> Register(RegisterModel model)
        {
            try
            {
                if (_dbContext.USERs.FirstOrDefault(x => x.PHONENO.Equals(model.phoneno)) != null)
                    return ReturnResponse.InvalidResult("Ийм дугаартай хэрэглэгч бүртгэгдсэн байна.");

                decimal userid = UsefulHelpers.GetTableID(_dbContext, "USER");
                _dbContext.USERs.Add(new USER
                {
                    ID = userid,
                    FIRSTNAME = model.firstname,
                    LASTNAME = model.lastname,
                    PHONENO = model.phoneno,
                    PASSWORD = model.password,
                    INSYMD = DateTime.Now,
                });

                _dbContext.SaveChanges();
                return ReturnResponse.ObjectResult(null);
            }
            catch (Exception ex)
            {
                return ReturnResponse.InvalidResult(ex);
            }
        }

        /// <summary>
        /// Login 
        /// </summary>
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ResponseClient> Login([FromBody] LoginModel model)
        {
            try
            {
                var user = _dbContext.USERs.FirstOrDefault(x => x.PHONENO.ToString() == model.phoneno && x.PASSWORD == model.password);
                if (user == null)
                    return ReturnResponse.InvalidResult("Таны утасны дугаар эсвэл нууц үг буруу байна, Та дахин оролдоно уу.");

                return ReturnResponse.ObjectResult(null);
            }
            catch (Exception ex)
            {
                return ReturnResponse.InvalidResult(ex);
            }
        }

        /// <summary>
        /// user list 
        /// </summary>
        [HttpPost]
        [Route("verifyuser")]
        [AllowAnonymous]
        public async Task<ResponseClient> VerifyingUser(List<IFormFile> img, IFormFile file, UserVerify model)
        {
            try
            {
                return CatalogLogic.UserVerify(_dbContext, file, img, model).Result;
            }
            catch (Exception ex)
            {
                return ReturnResponse.InvalidResult(ex);
            }
        }

        /// <summary> 
        /// category list
        /// </summary>
        [HttpGet]
        [Route("banner")]
        [AllowAnonymous]
        public async Task<ResponseClient> getBannerAll()
        {
            try
            {
                var categories = (from bau in _dbContext.BANNERs
                                  select new BannerModel
                                  {
                                      ID = bau.ID,
                                      IMG = bau.IMG,
                                      NAMEs = bau.NAME
                                  }).ToList();

                return ReturnResponse.ObjectResult(categories);
            }
            catch (Exception ex)
            {
                return ReturnResponse.InvalidResult(ex);
            }
        }

        /// <summary>
        /// add banner
        /// </summary>
        [HttpPost]
        [Route("addbanner")]
        [AllowAnonymous]
        public async Task<ResponseClient> AddBanner(List<IFormFile> img, AddBannerModel model)
        {
            try
            {
                return CatalogLogic.AddBanner(_dbContext, img, model).Result;
            }
            catch (Exception ex)
            {
                return ReturnResponse.InvalidResult(ex);
            }
        }

        /// <summary>
        /// user list 
        /// </summary>
        [HttpGet]
        [Route("user")]
        [AllowAnonymous]
        public async Task<ResponseClient> getUserAll()
        {
            try
            {
                var users = (from bau in _dbContext.USERs
                             select new UserModel
                             {
                                 ID = bau.ID,
                                 FIRSTNAME = bau.FIRSTNAME,
                                 LASTNAME = bau.LASTNAME,
                                 ROLE = bau.ROLE,
                                 IMAGE = bau.IMAGE,
                                 PHONENO = bau.PHONENO,
                                 ADDRESS = bau.ADDRESS,
                                 REGISTRNO = bau.REGISTRNO,
                                 INSYMD = bau.INSYMD,
                                 UPDYMD = bau.UPDYMD
                             }).ToList();

                return ReturnResponse.ObjectResult(users);
            }
            catch (Exception ex)
            {
                return ReturnResponse.InvalidResult(ex);
            }
        }

        /// <summary> 
        /// category list
        /// </summary>
        [HttpGet]
        [Route("category")]
        [AllowAnonymous]
        public async Task<ResponseClient> getCategoryAll()
        {
            try
            {
                var categories = (from bau in _dbContext.CATEGORYs
                             select new CategoryModel
                             {
                                 ID = bau.ID,
                                 NAME = bau.NAME,
                                 CONTRACTID = bau.CONTRACTID,
                                 CONTRACTNM = bau.CONTRACTNM,
                                 INSYMD = bau.INSYMD
                             }).ToList();

                return ReturnResponse.ObjectResult(categories);
            }
            catch (Exception ex)
            {
                return ReturnResponse.InvalidResult(ex);
            }
        }
        // IFormCollection data, IFormFile imageFile
        /// <summary>
        /// Login 
        /// </summary>
        [HttpPost]
        [Route("addcategory")]
        [AllowAnonymous]
        public async Task<ResponseClient> addCategory(IFormFile image, IFormFile file, string json)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<AddCategoryModel>(json);

                return CatalogLogic.AddCategory(_dbContext, file, image, model).Result;
            }
            catch (Exception ex)
            {
                return ReturnResponse.InvalidResult(ex);
            }
        }

        // IFormCollection data, IFormFile imageFile
        /// <summary>
        /// Login 
        /// </summary>
        [HttpPost]
        [Route("createorder")]
        [AllowAnonymous]
        public async Task<ResponseClient> CreateOrder(IFormFile image, CreateOrderModel model)
        {
            try
            {
                return CatalogLogic.CreateOrder(_dbContext, image, model).Result;
            }
            catch (Exception ex)
            {
                return ReturnResponse.InvalidResult(ex);
            }
        }
        /// <summary>
        /// Mobile	Tuhain asuulgad onoo uguh 
        /// </summary>
        [HttpPut]
        [Route("core/{userid}/{ansid}/{teamid}/{point}")]
        [AllowAnonymous]
        public async Task<ResponseClient> ScorePut(decimal userid, decimal ansid, decimal teamid, decimal point)
        {
            try
            {
                /*var newLog = new LOGS()
                {
                    ID = UsefulHelpers.GetTableID(_dbContext, typeof(LOGS).Name),
                    ANSID = ansid,
                    USERID = userid,
                    POINT = point,
                    TEAMID = teamid
                };
                _dbContext.LOGSs.Add(newLog);
                var team = _dbContext.TEAMs.FirstOrDefault(x => x.ID == teamid);
                team.POINT = team.POINT + point;
                _dbContext.Entry(team).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();*/
                return ReturnResponse.ObjectResult(null);
            }
            catch (Exception ex)
            {
                return ReturnResponse.InvalidResult(ex);
            }
        }

        #endregion
    }
}
