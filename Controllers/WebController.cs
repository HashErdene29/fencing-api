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
using NewsApi.Models.MedeeModels;
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

        #region
        /// <summary> 
        /// category list
        /// </summary>
        [HttpGet]
        [Route("news")]
        [AllowAnonymous]
        public async Task<ResponseClient> getNewsAll()
        {
            try
            {
                var news = (from bau in _dbContext.MEDEEs
                             select new MedeeModel
                             {
                                 ID = bau.ID,
                                 TITLE = bau.TITLE,
                                 DESCRIPTION = bau.DESCRIPTION,
                                 FEATURETXT = bau.FEATURETXT,
                                 IMG = bau.IMAGE
                             }).ToList();

                return ReturnResponse.ObjectResult(news);
            }
            catch (Exception ex)
            {
                return ReturnResponse.InvalidResult(ex);
            }
        }

        #endregion
    }
}
