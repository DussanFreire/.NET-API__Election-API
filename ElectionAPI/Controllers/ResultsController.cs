using ElectionAPI.Exceptions;
using ElectionAPI.Models;
using ElectionAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionAPI.Controllers
{
    [Route("api/[controller]")]
    public class ResultsController : ControllerBase
    {
        private IResultsService _resultsService;
        public ResultsController(IResultsService resultsService)
        {
            _resultsService = resultsService;
        }

        [HttpGet]
        public ActionResult<ResultsModel> GetResults()
        {
            try
            {
                var tables = _resultsService.GetResults();
                return Ok(tables);
            }
            catch (InvalidOperationItemException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
    }
}
