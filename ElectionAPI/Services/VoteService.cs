using ElectionAPI.Data.Repositories;
using ElectionAPI.Exceptions;
using ElectionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionAPI.Services
{
    public class VoteService : IVotesService
    {
        private IElectionRepository _electionRepository;

        public VoteService(IElectionRepository electionRepository)
        {
            _electionRepository = electionRepository;
        }


        public VoteModel CreateVote(long tableId, VoteModel newVote)
        {
            ValidateTable(tableId);
            var createdVote = _electionRepository.CreateVote(tableId, newVote);
            return createdVote;
        }

        public bool DeleteVote(long tableId, long voteId)
        {
            ValidateTableAndVote(tableId, voteId);
            _electionRepository.DeleteVote(tableId, voteId);
            return true;
        }

        public VoteModel GetVote(long tableId, long voteId)
        {
            ValidateTable(tableId);
            var voteModel = _electionRepository.GetVote(tableId, voteId);
            if (voteModel == null)
            {
                throw new NotFoundItemException($"The vote with id: {voteId} does not exist in table with id:{tableId}.");
            }
            return voteModel;
        }

        public IEnumerable<VoteModel> GetVotes(long tableId)
        {
            ValidateTable(tableId);
            var votes = _electionRepository.GetVotes(tableId);
            return votes;
        }

        public VoteModel UpdateVote(long tableId, long voteId, VoteModel updatedVote)
        {
            var voteModel = _electionRepository.UpdateVote(tableId, voteId, updatedVote);
            return voteModel;
        }

        private void ValidateTable(long tableId)
        {
            var table = _electionRepository.GetTable(tableId);
            if (table == null)
            {
                throw new NotFoundItemException($"The table with id: {tableId} doesn't exists.");
            }
        }
        private void ValidateTableAndVote(long tableId, long voteId)
        {
            var vote = GetVote(tableId, voteId);
        }
    }
}
