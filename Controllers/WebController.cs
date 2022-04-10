using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsApi.Context;
using NewsApi.Models.ElseltModels;
using NewsApi.Models;
using NewsApi.Utils;
using Newtonsoft.Json;
using NewsApi.Utils;
using System.Data;

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

        #region
        /// <summary> 
        /// news list
        /// </summary>
        [HttpGet]
        [Route("news")]
        [AllowAnonymous]
        public async Task<ResponseClient> getNewsAll()
        {
            try
            {
                //var news = (from bau in _dbContext.MEDEEs
                //             select new MedeeModel
                //             {
                //                 ID = bau.ID,
                //                 TITLE = bau.TITLE,
                //                 DESCRIPTION = bau.DESCRIPTION,
                //                 FEATURETXT = bau.FEATURETXT,
                //                 IMG = bau.IMAGE
                //             }).ToList();

                var list = _dbContext.MEDEEs.ToList();

                return ReturnResponse.ObjectResult(list);
            }
            catch (Exception ex)
            {
                return ReturnResponse.InvalidResult(ex);
            }
        }

        /// <summary> 
        /// elselt awah
        /// </summary>
        [HttpPost]
        [Route("elselt")]
        [AllowAnonymous]
        public async Task<ResponseClient> setElselt([FromBody] ElseltModel model)
        {
            try
            {
                var elselt = _dbContext.ELSELTs.Add( new ELSELT
                {
                    LASTNAME = model.lastname,
                    FIRSTNAME = model.firstname,
                    AGE = model.age,
                    HEIGHT = model.height,
                    WEIGHT = model.weight,
                    EMAIL = model.email,
                    PHONENUMBER = model.phonenumber,
                    ADDRESS = model.address,
                    DISTRICT = model.district,
                    RDNUMBER = model.rdnumber,
                    RELATION = model.relation,
                    RELATIONNAME = model.relationname,
                    RELATIONPHONENUMBER = model.relationphonenumber,
                    MALE = model.male,
                });

                _dbContext.SaveChanges();

                return ReturnResponse.SuccessResponse();
            }
            catch (Exception ex)
            {
                return ReturnResponse.InvalidResult(ex);
            }
        }

        #endregion
    }
}
