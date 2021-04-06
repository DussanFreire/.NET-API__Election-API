using ElectionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionAPI.Data.Repositories
{
    public interface IElectionRepository
    {
        //tables
        public IEnumerable<TableModel> GetTables(string orderBy = "Id");
        public TableWithVotesModel GetTable(long tableId);
        public TableModel CreateTable(TableModel newTable);
        public void DeleteTable(long tableId);
        public TableModel UpdateTable(long tableId, TableModel updatedTable);
        public TableWithVotesModel UpdateInvalidTable(long tableId);

        //votes
        public IEnumerable<VoteModel> GetVotes(long tableId);
        public VoteModel GetVote(long tableId, long voteId);
        public VoteModel CreateVote(long tableId, VoteModel newVote);
        public void DeleteVote(long tableId, long voteId);
        public VoteModel UpdateVote(long tableId, long voteId, VoteModel updatedVote);
    }
}
