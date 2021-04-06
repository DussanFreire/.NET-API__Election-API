using ElectionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionAPI.Data.Repositories
{
    public class ElectionRepository : IElectionRepository
    {
        private List<TableModel> _tables;
        private List<VoteModel> _votes;
        public ElectionRepository()
        {
            _tables = new List<TableModel>();
            _tables.Add(new TableModel()
            {
                Id = 1,
                Location = "Cercado",
                Number = 123

            });
            _tables.Add(new TableModel()
            {
                Id = 2,
                Location = "Quillacollo",
                Number = 321

            });
            _votes = new List<VoteModel>();
            _votes.Add(new VoteModel()
            {
                Id = 1,
                Name = "Jose perez",
                IsValid = true,
                PartyA = true,
                PartyB = false,
                PartyC = false,
                TableId = 1
            });
            _votes.Add(new VoteModel()
            {
                Id = 2,
                Name = "Marco Rojas",
                IsValid = true,
                PartyA = false,
                PartyB = true,
                PartyC = false,
                TableId = 2
            });
        }
        public TableModel CreateTable(TableModel newTable)
        {
            var nextId = _tables.OrderByDescending(t => t.Id).FirstOrDefault().Id + 1;
            newTable.Id = nextId;
            _tables.Add(newTable);
            return newTable;
        }

        public VoteModel CreateVote(long tableId, VoteModel newVote)
        {
            throw new NotImplementedException();
        }

        public void DeleteTable(long tableId)
        {
            var tableToDelete = _tables.First(t => t.Id == tableId);
            _tables.Remove(tableToDelete);
            _votes.RemoveAll(v => v.TableId == tableId);
        }

        public void DeleteVote(long tableId, long voteId)
        {
            throw new NotImplementedException();
        }

        public TableWithVotesModel GetTable(long tableId)
        {
            var table = _tables.FirstOrDefault(t => t.Id == tableId);
            IEnumerable<VoteModel> votes = new List<VoteModel>();
            if (table != null)
            {
                votes = _votes.Where(p => p.TableId == tableId);
                TableWithVotesModel tableWithVotes = new TableWithVotesModel()
                {
                    Id = table.Id,
                    Location = table.Location,
                    Number = table.Number,
                    Votes = votes
                };
                return tableWithVotes;
            }
            return null;
        }

        public IEnumerable<TableModel> GetTables(string orderBy = "Id")
        {
            return _tables.OrderBy(t => t.Id);
        }

        public VoteModel GetVote(long tableId, long voteId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VoteModel> GetVotes(long tableId)
        {
            throw new NotImplementedException();
        }

        public TableModel UpdateTable(long tableId, TableModel updatedTable)
        {
            throw new NotImplementedException();
        }

        public VoteModel UpdateVote(long tableId, long voteId, VoteModel updatedVote)
        {
            throw new NotImplementedException();
        }
    }
}
