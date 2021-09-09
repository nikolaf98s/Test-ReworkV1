using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyCat.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using SurveyCat.Service.Repository;
using SurveyCat.Service.Services;

namespace SurveyCat.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveyController : Controller
    {

        private readonly ISurveyService surveyService;
        public SurveyController(ISurveyService surveyService)
        {
            this.surveyService = surveyService;
        }

        // <summary>
        /// Get weather forecast for next 5 days.
        /// </summary>
        /// <returns>
        /// Weather forecast for next 5 days.
        /// </returns>
        [HttpGet("products")]
        [SwaggerOperation(OperationId = "Products", Summary = "List of products of given brandId")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ProductModel>), description: "successful operation")]
        [SwaggerResponse(statusCode: 400, description: "bad request")]
        [SwaggerResponse(statusCode: 404, description: "not found")]
        [SwaggerResponse(statusCode: 500, description: "internal server error")]
        public IActionResult GetProducts(Guid brandId)
        {
            List<ProductModel> result = this.surveyService.GetProducts(brandId);
      
            return this.Ok(result);
        }

        // <summary>
        /// Get weather forecast for next 5 days.
        /// </summary>
        /// <returns>
        /// Weather forecast for next 5 days.
        /// </returns>
        [HttpGet("brands")]
        [SwaggerOperation(OperationId = "Brands", Summary = "List of brands")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<BrandModel>), description: "successful operation")]
        [SwaggerResponse(statusCode: 400, description: "bad request")]
        [SwaggerResponse(statusCode: 404, description: "not found")]
        [SwaggerResponse(statusCode: 500, description: "internal server error")]
        public IActionResult GetBrands()
        {
            try
            {
                List<BrandModel> result = this.surveyService.GetBrands();
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
            
        }

        // <summary>
        /// Get weather forecast for next 5 days.
        /// </summary>
        /// <returns>
        /// Weather forecast for next 5 days.
        /// </returns>
        [HttpPost("survey")]
        [SwaggerOperation(OperationId = "addsurvey", Summary = "AddSurvey")]
        [SwaggerResponse(statusCode: 200, type: typeof(SurveyModel), description: "successful operation")]
        [SwaggerResponse(statusCode: 400, description: "bad request")]
        [SwaggerResponse(statusCode: 404, description: "not found")]
        [SwaggerResponse(statusCode: 500, description: "internal server error")]
        public IActionResult AddSurvey(SurveyModel surveyModel)
        {         
            try
            {
                this.surveyService.AddSurvey(surveyModel);
                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        // <summary>
        /// Get weather forecast for next 5 days.
        /// </summary>
        /// <returns>
        /// Weather forecast for next 5 days.
        /// </returns>
        [HttpGet("report")]
        [SwaggerOperation(OperationId = "getreport", Summary = "GetReport")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<SurveyModel>), description: "successful operation")]
        [SwaggerResponse(statusCode: 400, description: "bad request")]
        [SwaggerResponse(statusCode: 404, description: "not found")]
        [SwaggerResponse(statusCode: 500, description: "internal server error")]
        public IActionResult GetReport()
        {
            try
            {
                List<ReportModel> result = this.surveyService.GetReport();
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
