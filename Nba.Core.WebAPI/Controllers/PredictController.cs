using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nba.Core.IService;
using Nba.Core.Models.Entites;

namespace Nba.Core.WebAPI.Controllers
{
    [EnableCors("any")]
    [Route("api/[controller]")]
    [ApiController]
    public class PredictController : ControllerBase
    {
        private readonly IPredictResultService _predictResultService;
        public PredictController(IPredictResultService predictResultService)
        {
            _predictResultService = predictResultService;
        }


        [HttpGet]
        [Route("/api/Predict/GetAllTeamInfos")]
        public ResponseOutput GetAllTeamInfos()
        {
            try
            {
                var resultItems = _predictResultService.GetList();
                return new ResponseOutput(resultItems, "0", string.Empty, HttpContext.TraceIdentifier);
            }
            catch (Exception ex)
            {
                return new ResponseOutput(null, "-1", ex.Message, HttpContext.TraceIdentifier);
            }

        }


        //[HttpGet]
        //[Route("/api/Predict/GetAllPredictResult")]
        //public List<PredictResult> GetAllPredictResult()
        //{
        //    try
        //    {
        //        return  _predictResultService.GetList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}



    }
}