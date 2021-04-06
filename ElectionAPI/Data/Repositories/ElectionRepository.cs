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
                DateRegistered = new DateTime(2021, 1, 17, 17, 40, 0),
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
                DateRegistered = new DateTime(2021, 1, 17, 11, 14, 0),
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
            newVote.TableId = tableId;
            var nextId = _votes.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
            newVote.Id = nextId;
            _votes.Add(newVote);
            return newVote;
        }

        public void DeleteTable(long tableId)
        {
            var tableToDelete = _tables.First(t => t.Id == tableId);
            _tables.Remove(tableToDelete);
            _votes.RemoveAll(v => v.TableId == tableId);
        }

        public void DeleteVote(long tableId, long voteId)
        {
            var voteToDelete = _votes.FirstOrDefault(v => v.TableId == tableId && v.Id == voteId);
            _votes.Remove(voteToDelete);
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
            return _votes.FirstOrDefault(v => v.TableId == tableId && v.Id == voteId);
        }

        public IEnumerable<VoteModel> GetVotes(long tableId)
        {
            return _votes.Where(v => v.TableId == tableId);
        }

        public TableModel UpdateTable(long tableId, TableModel updatedTable)
        {
            var table = _tables.First(t => t.Id == tableId);
            table.Number = updatedTable.Number ?? table.Number;
            table.Location = updatedTable.Location ?? table.Location;
            return table;
        }

        public VoteModel UpdateVote(long tableId, long voteId, VoteModel updatedVote)
        {
            var voteToUpdate = _votes.FirstOrDefault(v => v.TableId == tableId && v.Id == voteId);
            voteToUpdate.Name = updatedVote.Name ?? voteToUpdate.Name;
            voteToUpdate.PartyA = updatedVote.PartyA ?? voteToUpdate.PartyA;
            voteToUpdate.PartyB = updatedVote.PartyB ?? voteToUpdate.PartyB;
            voteToUpdate.PartyC = updatedVote.PartyC ?? voteToUpdate.PartyC;
            voteToUpdate.DateRegistered = updatedVote.DateRegistered ?? voteToUpdate.DateRegistered;

            return updatedVote;
        }
    }
}
