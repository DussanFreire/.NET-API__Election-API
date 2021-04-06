using ElectionAPI.Data.Repositories;
using ElectionAPI.Exceptions;
using ElectionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionAPI.Services
{
    public class ResultsService : IResultsService
    {
        private IElectionRepository _electionRepository;

        public ResultsService(IElectionRepository electionRepository)
        {
            _electionRepository = electionRepository;
        }

        public ResultsModel GetResults()
        {
            var voteEnumerable = _electionRepository.GetAllVotes();
            var results = CalculateRasults(voteEnumerable);
            return results;
        }
        private ResultsModel CalculateRasults(IEnumerable<VoteModel> voteEnumerable)
        {
            var voteList = voteEnumerable.ToList();
            long partyAVotes = voteList.Where(t => t.PartyA == true && t.IsValid == true).Count();
            long partyBVotes = voteList.Where(t => t.PartyB == true && t.IsValid == true).Count();
            long partyCVotes = voteList.Where(t => t.PartyC == true && t.IsValid == true).Count();
            long BlankVotes = voteList.Where(t => t.BlankVote == true).Count();
            long InvalidVotes = voteList.Where(t => t.IsValid == false).Count();
            long TotalVotes = voteList.Count();
            Dictionary<string, long> VotesPartys = new Dictionary<string, long>() { { "partyA", partyAVotes }, { "partyB", partyBVotes }, { "partyC", partyCVotes } };
            string winner = VotesPartys.Where(d => d.Value == VotesPartys.Values.Max()).Count() == 1 ? VotesPartys.First(d => d.Value == VotesPartys.Values.Max()).Key : "Empate";
            ResultsModel results = new ResultsModel()
            {
                Winner = winner,
                PartyAVotes = partyAVotes,
                PartyBVotes = partyBVotes,
                PartyCVotes = partyCVotes,
                BlankVotes = BlankVotes,
                InvalidVotes = InvalidVotes,
                TotalVotes = TotalVotes,
                ValidVotes = TotalVotes - InvalidVotes
            };
            return results;
        }
    }
}
//long partyAVotes = tableList.Select(t => t.Votes.Where(t => t.PartyA == true).Count()).Sum();
//long partyBVotes = tableList.Select(t => t.Votes.Where(t => t.PartyB == true).Count()).Sum();
//long partyCVotes = tableList.Select(t => t.Votes.Where(t => t.PartyC == true).Count()).Sum();
//long BlankVotes = tableList.Select(t => t.Votes.Where(t => t.BlankVote == true).Count()).Sum();
//long InvalidVotes = tableList.Select(t => t.Votes.Where(t => t.IsValid == false).Count()).Sum();
//long TotalVotes = tableList.Select(t => t.Votes.Count()).Sum();