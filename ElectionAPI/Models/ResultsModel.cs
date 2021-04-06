using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionAPI.Models
{
    public class ResultsModel
    {
        public long? PartyA { get; set; }
        public long? PartyB { get; set; }
        public long? PartyC { get; set; }
        public long? IsValid { get; set; }
        public long? BlankVote { get; set; }
    }
}
