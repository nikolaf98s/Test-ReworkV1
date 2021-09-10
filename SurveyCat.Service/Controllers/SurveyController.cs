
namespace SurveyCat.Service.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using SurveyCat.Service.Models;
    using SurveyCat.Service.Services;
    using Swashbuckle.AspNetCore.Annotations;

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
        /// Get products from brand guid
        /// </summary>
        /// <returns>
        /// Get products
        /// </returns>
        [HttpGet("products")]
        [SwaggerOperation(OperationId = "Products", Summary = "List of products of given brandId")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Product>), description: "successful operation")]
        [SwaggerResponse(statusCode: 400, description: "bad request")]
        [SwaggerResponse(statusCode: 404, description: "not found")]
        [SwaggerResponse(statusCode: 500, description: "internal server error")]
        public IActionResult GetProducts(Guid brandId)
        {
            try
            {
                List<Product> result = this.surveyService.GetProducts(brandId);
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        // <summary>
        /// Get brands
        /// </summary>
        /// <returns>
        /// Get brands
        /// </returns>
        [HttpGet("brands")]
        [SwaggerOperation(OperationId = "Brands", Summary = "List of brands")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Brand>), description: "successful operation")]
        [SwaggerResponse(statusCode: 400, description: "bad request")]
        [SwaggerResponse(statusCode: 404, description: "not found")]
        [SwaggerResponse(statusCode: 500, description: "internal server error")]
        public IActionResult GetBrands()
        {
            try
            {
                List<Brand> result = this.surveyService.GetBrands();
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
            
        }

        // <summary>
        /// Add survey 
        /// </summary>
        /// <returns>
        ///  Add survey 
        /// </returns>
        [HttpPost("survey")]
        [SwaggerOperation(OperationId = "Survey", Summary = "AddSurvey")]
        [SwaggerResponse(statusCode: 200, type: typeof(Survey), description: "successful operation")]
        [SwaggerResponse(statusCode: 400, description: "bad request")]
        [SwaggerResponse(statusCode: 404, description: "not found")]
        [SwaggerResponse(statusCode: 500, description: "internal server error")]
        public IActionResult AddSurvey(Survey surveyModel)
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
        ///  Get report 
        /// </summary>
        /// <returns>
        /// Get report
        /// </returns>
        [HttpGet("report")]
        [SwaggerOperation(OperationId = "Report", Summary = "GetReport")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Report>), description: "successful operation")]
        [SwaggerResponse(statusCode: 400, description: "bad request")]
        [SwaggerResponse(statusCode: 404, description: "not found")]
        [SwaggerResponse(statusCode: 500, description: "internal server error")]
        public IActionResult GetReport()
        {
            try
            {
                List<Report> result = this.surveyService.GetReport();
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
