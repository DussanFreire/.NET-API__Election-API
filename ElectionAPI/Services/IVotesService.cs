using ElectionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionAPI.Services
{
    public interface IVotesService
    {
        public IEnumerable<VoteModel> GetVotes(long tableId);
        public VoteModel GetVote(long tableId, long voteId);
        public VoteModel CreateVote(long tableId, VoteModel newVote);
        public bool DeleteVote(long tableId, long voteId);
        public VoteModel UpdateVote(long tableId, long voteId, VoteModel updatedVote);
    }
}
