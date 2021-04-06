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
    public class TablesController : ControllerBase
    {
        private ITablesService  _tablesService;
        public TablesController(ITablesService tablesService)
        {
            _tablesService = tablesService;
        }
        //getAll
        [HttpGet]
        public ActionResult<IEnumerable<TableModel>> GetTables(string orderBy = "Id")
        {
            try
            {
                var tables = _tablesService.GetTables(orderBy);
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

        //get
        [HttpGet("{tableId:long}")]
        public ActionResult<TableWithVotesModel> GetTable(long tableId)
        {
            try
            {
                var table = _tablesService.GetTable(tableId);
                return Ok(table);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
        //create
        [HttpPost]
        public ActionResult<TableModel> CreateTable([FromBody] TableModel newTable)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var table = _tablesService.CreateTable(newTable);
                return Created($"/api/tables/{table.Id}", table);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
        //delete
        [HttpDelete("{tableId:long}")]
        public ActionResult<bool> DeleteTable(long tableId)
        {
            try
            {
                var result = _tablesService.DeleteTable(tableId);
                return Ok(result);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        //put
        [HttpPut("{tableId:long}")]
        public ActionResult<TableModel> UpdateTable(long tableId, [FromBody] TableModel updatedTable)
        {
            try
            {
          
                var table = _tablesService.UpdateTable(tableId, updatedTable);
                return Ok(table);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

    }
}
