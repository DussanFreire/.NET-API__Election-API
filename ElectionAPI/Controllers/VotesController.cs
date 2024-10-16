﻿using ElectionAPI.Exceptions;
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
    [Route("api/tables/{tableId:long}/[controller]")]
    public class VotesController : ControllerBase
    {
        private IVotesService _voteService;

        public VotesController(IVotesService voteService)
        {
            _voteService = voteService;
        }
        //get
        [HttpGet("{voteId:long}")]
        public IActionResult GetVote(long tableId, long voteId)
        {
            try
            {
                var vote = _voteService.GetVote(tableId, voteId);
                return Ok(vote);
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
        //getAll
        [HttpGet]
        public ActionResult<IEnumerable<VoteModel>> GetVotes(long tableId, string filter = "All")
        {
            try
            {
                var votes = _voteService.GetVotes(tableId, filter);
                return Ok(votes);
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
        public ActionResult<VoteModel> CreateVote(long tableId, [FromBody] VoteModel newVote)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdVote = _voteService.CreateVote(tableId, newVote);
                return Created($"/api/tables/{tableId}/votes/{createdVote.Id}", createdVote);
            }
            catch (InvalidOperationItemException ex)
            {
                return NotFound(ex.Message);
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
        //delete
        [HttpDelete("{voteId:int}")]
        public ActionResult<bool> DeleteVote(long tableId, long voteId)
        {
            try
            {
                var result = _voteService.DeleteVote(tableId, voteId);
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
        //update
        [HttpPut("{voteId:long}")]
        public ActionResult<VoteModel> UpdateVote(long tableId, long voteId, [FromBody] VoteModel voteToUpdate)
        {
            try
            {
                var updatedPayer = _voteService.UpdateVote(tableId, voteId, voteToUpdate);
                return Ok(updatedPayer);
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
