using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionAPI.Models
{
    public class ResultsModel
    {
        public string Winner { get; set; }
        public long? TotalVotes { get; set; }
        public long? PartyAVotes { get; set; }
        public long? PartyBVotes { get; set; }
        public long? PartyCVotes { get; set; }
        public long? ValidVotes { get; set; }
        public long? InvalidVotes { get; set; }
        public long? BlankVotes { get; set; }
    }
}
