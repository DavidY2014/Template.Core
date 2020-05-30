using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Nba.Core.Common;
using Nba.Core.Common.Extensions;
using Nba.Core.IService;

namespace Nba.Core.WebAPI.Controllers
{
    /// <summary>
    /// 此接口可废弃
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CsvConvertController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IPredictResultService _predictResultService;
        public CsvConvertController(IWebHostEnvironment hostingEnvironment, IPredictResultService predictResultService)
        {
            _hostingEnvironment = hostingEnvironment;
            _predictResultService = predictResultService;
        }

        /// <summary>
        /// 此接口是用来将python 预测的csv文件插入数据库,此接口不能暴露给用户
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("/api/CsvConvert/GenerateResultToDatabase")]
        public ResponseOutput GenerateResultToDatabase()
        {
            try
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var predictResultList = CsvConvertHelper.ParseCsvDemo(Path.Combine(webRootPath,"Result.csv"));
                _predictResultService.Add(predictResultList.ConvertItems());

                return new ResponseOutput("Success", "0", string.Empty, HttpContext.TraceIdentifier);
            }
            catch (Exception ex)
            {
                return new ResponseOutput("Wrong", "-1", ex.Message, HttpContext.TraceIdentifier);
            }

        }


    }
}